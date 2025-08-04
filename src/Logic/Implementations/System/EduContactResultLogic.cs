using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models;
using Entities.Models.System;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class EduContactResultLogic(
    IRepository<EduContactResult> repository,
    IRepository<StudentData> studentRepository,
    IRepository<AcademyData> academyRepository, 
    IFileService fileService,
    IUnitOfWork unitOfWork
) : IEduContactResult
{
    public async Task<Result<EduContactResultDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<EduContactResultDto>())
            : Result.Failure<EduContactResultDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<EduContactResultDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<EduContactResultDto>>())
            : Result.Failure<IReadOnlyCollection<EduContactResultDto>>(result.Error);
    }

    public async Task<Result<EduContactResultDto>> CreateAsync(EduContactResultDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<EduContactResultDto>(check.Error);

        var entity = dto.Adapt<EduContactResult>();
        if (dto.Attachment is not null)
        {
            var path = await fileService.SaveAsync<EduContactResult>(dto.Attachment);
            entity.Attachment = path;
        }
        var insertResult = await repository.InsertAsync(entity, cancellationToken);
        if (insertResult.IsFailure) return Result.Failure<EduContactResultDto>(insertResult.Error);
       

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(entity.Adapt<EduContactResultDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, EduContactResultDto dto, CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        var entity = getResult.Value;

        if (dto.Attachment is not null)
        {
            var path = await fileService.SaveAsync<EduContactResult>(dto.Attachment);
            entity.Attachment = path;
        }

        dto.Adapt(entity);
        var update = await repository.UpdateAsync(entity, cancellationToken);
        if (update.IsFailure) return Result.Failure<bool>(update.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if (entity.IsSuccess)
        {
            if (!string.IsNullOrWhiteSpace(entity.Value.Attachment))
            {
                var deleted = fileService.Delete<EduContactResult>(entity.Value.Attachment);
                if(!deleted)
                    return Result.Failure<bool>(Error.Problem("Delete.Failed",$"Delete file of entity with id {id} has been failed."));
            }
            
        }
        var result = await repository.DeleteByIdAsync(id, cancellationToken);
        
        if (result.IsFailure) return Result.Failure<bool>(result.Error);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(true);
    }

    public async Task<Result<IReadOnlyCollection<EduContactResultDto>>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x => x.StudentDataId == studentId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<EduContactResultDto>>())
            : Result.Failure<IReadOnlyCollection<EduContactResultDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<EduContactResultDto>>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x => x.DateResult >= from && x.DateResult <= to, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<EduContactResultDto>>())
            : Result.Failure<IReadOnlyCollection<EduContactResultDto>>(result.Error);
    }

    public async Task<Result<(FileStream? Stream, string? ContentType)>> GetAttachmentAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x=>x.Id == id && x.Attachment != null, cancellationToken);
        if(entity.IsFailure)
            return Result.Failure<(FileStream?, string?)>(entity.Error);
        
        var (stream, ext) = await Task.FromResult(fileService.Get<EduContactResult>(entity.Value.Attachment!));
        
        if (stream is null)
            return Result.Failure<(FileStream?, string?)>(Error.NotFound("FileNotFound", $"No file for EduContactResult with ID {id}"));

        return Result.Success(((FileStream?)stream, GetMimeType(ext)));
    }

    private async Task<Result> ValidateRelationsAsync(EduContactResultDto dto, CancellationToken ct)
    {
        if (dto.AcademyDataId is not null)
        {
            var companyExists = await academyRepository.AnyAsync(x => x.Id == dto.AcademyDataId, ct);
            if (!companyExists)
                return Result.Failure(Error.NotFound("Company.NotFound", $"Company ID {dto.AcademyDataId} not found"));
        }

        if (dto.StudentDataId is not null)
        {
            var studentExists = await studentRepository.AnyAsync(x => x.Id == dto.StudentDataId, ct);
            if (!studentExists)
                return Result.Failure(Error.NotFound("Student.NotFound", $"Student ID {dto.StudentDataId} not found"));
        }

        return Result.Success();
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
}
