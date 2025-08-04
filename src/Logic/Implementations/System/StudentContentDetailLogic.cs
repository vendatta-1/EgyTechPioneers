using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class StudentContentDetailLogic(
    IRepository<StudentContentDetail> repository,
    IRepository<ProgramsContentDetail> programsContentDetailRepo,
    IRepository<StudentData> studentDataRepo,
    IFileService fileService,
    IUnitOfWork unitOfWork) : IStudentContentDetail
{
    public async Task<Result<StudentContentDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<StudentContentDetailDto>())
            : Result.Failure<StudentContentDetailDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentContentDetailDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentContentDetailDto>>())
            : Result.Failure<IReadOnlyCollection<StudentContentDetailDto>>(result.Error);
    }

    public async Task<Result<StudentContentDetailDto>> CreateAsync(StudentContentDetailDto dto,
        CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<StudentContentDetailDto>(check.Error);

        var entity = dto.Adapt<StudentContentDetail>();

        if (dto.SessionTasks is not null)
            entity.SessionTasks = await fileService.SaveAsync<StudentContentDetail>(dto.SessionTasks);

        if (dto.SessionProject is not null)
            entity.SessionProject = await fileService.SaveAsync<StudentContentDetail>(dto.SessionProject);

        if (dto.SessionQuiz is not null)
            entity.SessionQuiz = await fileService.SaveAsync<StudentContentDetail>(dto.SessionQuiz);

        var insertResult = await repository.InsertAsync(entity, cancellationToken);
        if (insertResult.IsFailure) return Result.Failure<StudentContentDetailDto>(insertResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(entity.Adapt<StudentContentDetailDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentContentDetailDto dto,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        var entity = result.Value;
        dto.Adapt(entity);

        if (dto.SessionTasks is not null)
            entity.SessionTasks = await fileService.SaveAsync<StudentContentDetail>(dto.SessionTasks);

        if (dto.SessionProject is not null)
            entity.SessionProject = await fileService.SaveAsync<StudentContentDetail>(dto.SessionProject);

        if (dto.SessionQuiz is not null)
            entity.SessionQuiz = await fileService.SaveAsync<StudentContentDetail>(dto.SessionQuiz);

        var updateResult = await repository.UpdateAsync(entity, cancellationToken);
        if (updateResult.IsFailure) return Result.Failure<bool>(updateResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        var deleteResult = await repository.DeleteByIdAsync(id, cancellationToken);

        if (deleteResult.IsFailure) return Result.Failure<bool>(deleteResult.Error);

        if (entity.Value.SessionProject is not null)
            fileService.Delete<StudentContentDetail>(entity.Value.SessionProject);
        
        if (entity.Value.SessionQuiz is not null)
            fileService.Delete<StudentContentDetail>(entity.Value.SessionQuiz);
        
        if (entity.Value.SessionTasks is not null)
            fileService.Delete<StudentContentDetail>(entity.Value.SessionTasks);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<(FileStream?, string?)>> GetSessionTasksAsync(Guid id,
        CancellationToken cancellationToken = default)
        => await GetFileResult(id,nameof(StudentContentDetail.SessionTasks) ,cancellationToken);

    public async Task<Result<(FileStream?, string?)>> GetSessionProjectAsync(Guid id,
        CancellationToken cancellationToken = default)
        => await GetFileResult(id, nameof(StudentContentDetail.SessionProject),cancellationToken);

    public async Task<Result<(FileStream?, string?)>> GetSessionQuizAsync(Guid id,
        CancellationToken cancellationToken = default)
        => await GetFileResult(id,nameof(StudentContentDetail.SessionQuiz), cancellationToken);

    private async Task<Result<(FileStream?, string?)>> GetFileResult(Guid id,string name, CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        if (result.IsFailure)
            return Result.Failure<(FileStream?, string?)>(result.Error);

        var property = result.Value.GetType().GetProperty(name);
        if (property == null)
            return Result.Failure<(FileStream?, string?)>(Error.Failure("Property.NotFound", $"Property '{name}' not found on StudentContentDetail"));

        var fileId = property.GetValue(result.Value) as string;
        var (stream, ext) = fileService.Get<StudentContentDetail>(fileId);
    
        if (stream is null)
            return Result.Failure<(FileStream?, string?)>(Error.NotFound("FileNotFound", $"No file found for ID: {id}"));

        return Result.Success((stream, GetMimeType(ext)));
    }

    private static string? GetMimeType(string? ext)
    {
        if (string.IsNullOrWhiteSpace(ext)) return null;
        return ext.ToLower() switch
        {
            ".pdf" => "application/pdf",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".txt" => "text/plain",
            _ => "application/octet-stream"
        };
    }

    private async Task<Result> ValidateRelationsAsync(StudentContentDetailDto dto, CancellationToken ct)
    {
        if (dto.ProgramsContentDetailsId is not null)
        {
            var exists = await programsContentDetailRepo.AnyAsync(x => x.Id == dto.ProgramsContentDetailsId, ct);
            if (!exists)
                return Result.Failure(Error.NotFound("ProgramsContentDetail.NotFound",
                    "ProgramsContentDetail ID not found"));
        }

        if (dto.StudentDataId is not null)
        {
            var exists = await studentDataRepo.AnyAsync(x => x.Id == dto.StudentDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("StudentData.NotFound", "StudentData ID not found"));
        }

        return Result.Success();
    }
}