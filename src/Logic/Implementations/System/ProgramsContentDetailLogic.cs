using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Result<IReadOnlyCollection<ProgramsContentDetailDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProgramsContentDetailDto>>())
            : Result.Failure<IReadOnlyCollection<ProgramsContentDetailDto>>(result.Error);
    }

    public async Task<Result<ProgramsContentDetailDto>> CreateAsync(ProgramsContentDetailDto dto,
        CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<ProgramsContentDetailDto>(check.Error);

        var entity = dto.Adapt<ProgramsContentDetail>();

        if (dto.SessionTasksFile is not null)
            entity.SessionTasks = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionTasksFile, "_tasks");

        if (dto.SessionProjectFile is not null)
            entity.SessionProject =
                await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionProjectFile, "_project");

        if (dto.ScientificMaterialFile is not null)
            entity.ScientificMaterial =
                await fileService.SaveAsync<ProgramsContentDetail>(dto.ScientificMaterialFile, "_material");

        if (dto.SessionQuiz is not null)
            entity.SessionQuiz = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionQuiz, "_quiz");

        var result = await repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure) return Result.Failure<ProgramsContentDetailDto>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(entity.Adapt<ProgramsContentDetailDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ProgramsContentDetailDto dto,
        CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        var entity = getResult.Value;
        dto.Adapt(entity);

        if (dto.SessionTasksFile is not null)
            entity.SessionTasks = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionTasksFile, "_tasks");

        if (dto.SessionProjectFile is not null)
            entity.SessionProject =
                await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionProjectFile, "_project");

        if (dto.ScientificMaterialFile is not null)
            entity.ScientificMaterial =
                await fileService.SaveAsync<ProgramsContentDetail>(dto.ScientificMaterialFile, "_material");

        if (dto.SessionQuiz is not null)
            entity.SessionQuiz = await fileService.SaveAsync<ProgramsContentDetail>(dto.SessionQuiz, "_quiz");

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

        if (!string.IsNullOrWhiteSpace(entity.SessionTasks) &&
            !fileService.Delete<ProgramsContentDetail>(entity.SessionTasks, "_tasks"))
            failedDeletes.Add("_tasks");

        if (!string.IsNullOrWhiteSpace(entity.SessionProject) &&
            !fileService.Delete<ProgramsContentDetail>(entity.SessionProject, "_project"))
            failedDeletes.Add("_project");

        if (!string.IsNullOrWhiteSpace(entity.ScientificMaterial) &&
            !fileService.Delete<ProgramsContentDetail>(entity.ScientificMaterial, "_material"))
            failedDeletes.Add("_material");

        if (!string.IsNullOrWhiteSpace(entity.SessionQuiz) &&
            !fileService.Delete<ProgramsContentDetail>(entity.SessionQuiz, "_quiz"))
            failedDeletes.Add("_quiz");

        if (failedDeletes.Count > 0)
        {
            return Result.Failure<bool>(
                Error.Problem("Delete.FileFailed",
                    $"Failed to delete files: {string.Join(", ", failedDeletes)} for entity {id}")
            );
        }

        var deleteResult = await repository.DeleteByIdAsync(id, cancellationToken);
        if (deleteResult.IsFailure) return Result.Failure<bool>(deleteResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<(FileStream Stream, string? FileName, string? ContentType)>> GetSessionTasksAsync(Guid id, CancellationToken cancellationToken = default)
        => await GetFile(id, "_tasks", e => e.SessionTasks);

    public async Task<Result<(FileStream Stream, string? FileName, string? ContentType)>> GetSessionProjectAsync(Guid id, CancellationToken cancellationToken = default)
        => await GetFile(id, "_project", e => e.SessionProject);

    public async Task<Result<(FileStream Stream, string? FileName, string? ContentType)>> GetScientificMaterialAsync(Guid id, CancellationToken cancellationToken = default)
        => await GetFile(id, "_material", e => e.ScientificMaterial);

    public async Task<Result<(FileStream Stream, string? FileName, string? ContentType)>> GetSessionQuizAsync(Guid id, CancellationToken cancellationToken = default)
        => await GetFile(id, "_quiz", e => e.SessionQuiz);

    private async Task<Result<(FileStream Stream, string? FileName, string? ContentType)>> GetFile(Guid id, string suffix, Func<ProgramsContentDetail, string?> fileSelector)
    {
        var entityResult = await repository.GetByIdAsync(id);
        if (entityResult.IsFailure)
            return Result.Failure<(FileStream, string?, string?)>(entityResult.Error);

        var filePath = fileSelector(entityResult.Value);
        if (string.IsNullOrWhiteSpace(filePath))
            return Result.Failure<(FileStream, string?, string?)>(
                Error.NotFound("FileNotFound", $"No file found for ID: {id}")
            );

        var (stream, fileName) = fileService.Get<ProgramsContentDetail>(filePath, suffix);
        if (stream is null || fileName is null)
            return Result.Failure<(FileStream, string?, string?)>(
                Error.NotFound("FileNotFound", $"No file found for ID: {id}")
            );

        var contentType = GetMimeType(Path.GetExtension(fileName));
        return Result.Success((stream, fileName, contentType));
    }

    private string? GetMimeType(string? ext)
    {
        return fileService.GetMimeType(ext ?? "");
    }

    private async Task<Result> ValidateRelationsAsync(ProgramsContentDetailDto dto, CancellationToken ct)
    {
        {
            var exists = await masterRepo.AnyAsync(x => x.Id == dto.ProgramsContentMasterId, ct);
            if (!exists)
                return Result.Failure(Error.NotFound("ProgramsContentMaster.NotFound",
                    "ProgramsContentMaster not found"));
        }

        return Result.Success();
    }
}