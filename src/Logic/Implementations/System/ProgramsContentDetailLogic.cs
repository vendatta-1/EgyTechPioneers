using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class ProgramsContentDetailLogic(
    IRepository<ProgramsContentDetail> repository,
    IRepository<ProgramsContentMaster> masterRepo,
    IFileService fileService,
    IUnitOfWork unitOfWork) : IProgramsContentDetail
{
    public async Task<Result<ProgramsContentDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<ProgramsContentDetailDto>())
            : Result.Failure<ProgramsContentDetailDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ProgramsContentDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProgramsContentDetailDto>>())
            : Result.Failure<IReadOnlyCollection<ProgramsContentDetailDto>>(result.Error);
    }

    public async Task<Result<ProgramsContentDetailDto>> CreateAsync(ProgramsContentDetailDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<ProgramsContentDetailDto>(check.Error);

        var entity = dto.Adapt<ProgramsContentDetail>();

        if (dto.SessionTasks is not null)
            entity.SessionTasks = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionTasks, entity.Id, "_tasks");

        if (dto.SessionProject is not null)
            entity.SessionProject = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionProject, entity.Id, "_project");

        if (dto.ScientificMaterial is not null)
            entity.ScientificMaterial = await fileService.SaveAsync<ProgramsContentDetail>(dto.ScientificMaterial, entity.Id, "_material");

        if (dto.SessionQuiz is not null)
            entity.SessionQuiz = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionQuiz, entity.Id, "_quiz");

        var result = await repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure) return Result.Failure<ProgramsContentDetailDto>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(entity.Adapt<ProgramsContentDetailDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ProgramsContentDetailDto dto, CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        var entity = getResult.Value;
        dto.Adapt(entity);

        if (dto.SessionTasks is not null)
            entity.SessionTasks = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionTasks, id, "_tasks");

        if (dto.SessionProject is not null)
            entity.SessionProject = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionProject, id, "_project");

        if (dto.ScientificMaterial is not null)
            entity.ScientificMaterial = await fileService.SaveAsync<ProgramsContentDetail>(dto.ScientificMaterial, id, "_material");

        if (dto.SessionQuiz is not null)
            entity.SessionQuiz = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionQuiz, id, "_quiz");

        var updateResult = await repository.UpdateAsync(entity, cancellationToken);
        if (updateResult.IsFailure) return Result.Failure<bool>(updateResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var entity = getResult.Value;

       
        var failedDeletes = new List<string>();

        if (!string.IsNullOrWhiteSpace(entity.SessionTasks) && !fileService.Delete<ProgramsContentDetail>(id, "_tasks"))
            failedDeletes.Add("_tasks");

        if (!string.IsNullOrWhiteSpace(entity.SessionProject) && !fileService.Delete<ProgramsContentDetail>(id, "_project"))
            failedDeletes.Add("_project");

        if (!string.IsNullOrWhiteSpace(entity.ScientificMaterial) && !fileService.Delete<ProgramsContentDetail>(id, "_material"))
            failedDeletes.Add("_material");

        if (!string.IsNullOrWhiteSpace(entity.SessionQuiz) && !fileService.Delete<ProgramsContentDetail>(id, "_quiz"))
            failedDeletes.Add("_quiz");

        if (failedDeletes.Count > 0)
        {
            return Result.Failure<bool>(
                Error.Problem("Delete.FileFailed", $"Failed to delete files: {string.Join(", ", failedDeletes)} for entity {id}")
            );
        }

        var deleteResult = await repository.DeleteByIdAsync(id, cancellationToken);
        if (deleteResult.IsFailure) return Result.Failure<bool>(deleteResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }
    public async Task<Result<(FileStream Stream, string? ContentType)>> GetSessionTasksAsync(Guid id, CancellationToken cancellationToken = default)
        => await GetFile(id, "_tasks");

    public async Task<Result<(FileStream Stream, string? ContentType)>> GetSessionProjectAsync(Guid id, CancellationToken cancellationToken = default)
        => await GetFile(id, "_project");

    public async Task<Result<(FileStream Stream, string? ContentType)>> GetScientificMaterialAsync(Guid id, CancellationToken cancellationToken = default)
        => await GetFile(id, "_material");

    public async Task<Result<(FileStream Stream, string? ContentType)>> GetSessionQuizAsync(Guid id, CancellationToken cancellationToken = default)
        => await GetFile(id, "_quiz");

    private async Task<Result<(FileStream Stream, string? ContentType)>> GetFile(Guid id, string suffix)
    {
        var (stream, ext) = fileService.Get<ProgramsContentDetail>(id, suffix);
        if (stream is null)
            return Result.Failure<(FileStream, string?)>(Error.NotFound("FileNotFound", $"No file found for ID: {id}"));

        return Result.Success((stream, GetMimeType(ext)));
    }

    private static string? GetMimeType(string? ext) => ext?.ToLower() switch
    {
        ".pdf" => "application/pdf",
        ".jpg" or ".jpeg" => "image/jpeg",
        ".png" => "image/png",
        ".doc" => "application/msword",
        ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        ".txt" => "text/plain",
        _ => "application/octet-stream"
    };

    private async Task<Result> ValidateRelationsAsync(ProgramsContentDetailDto dto, CancellationToken ct)
    {
        if (dto.ProgramsContentMasterId is not null)
        {
            var exists = await masterRepo.AnyAsync(x => x.Id == dto.ProgramsContentMasterId, ct);
            if (!exists) return Result.Failure(Error.NotFound("ProgramsContentMaster.NotFound", "ProgramsContentMaster not found"));
        }

        return Result.Success();
    }
}
