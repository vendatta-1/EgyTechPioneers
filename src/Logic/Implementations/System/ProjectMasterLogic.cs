using Common.Data;
using Entities.Models.System;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Common.Results;
using Dtos.System;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class ProjectsMasterLogic(
    IRepository<ProjectsMaster> repository,
    IFileService fileService,
    IUnitOfWork unitOfWork
) : IProjectsMaster
{
    public async Task<Result<ProjectsMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<ProjectsMasterDto>())
            : Result.Failure<ProjectsMasterDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ProjectsMasterDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProjectsMasterDto>>())
            : Result.Failure<IReadOnlyCollection<ProjectsMasterDto>>(result.Error);
    }

    public async Task<Result<ProjectsMasterDto>> CreateAsync(ProjectsMasterDto dto,
        CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<ProjectsMaster>();
        var insertResult = await repository.InsertAsync(entity, cancellationToken);
        if (!insertResult.IsSuccess) return Result.Failure<ProjectsMasterDto>(insertResult.Error);

        if (dto.ProjectResources is not null)
            entity.ProjectResources =
                await fileService.SaveAsync<ProjectsMaster>(dto.ProjectResources, "resource.dat");

        if (dto.ProjectFiles is not null)
            entity.ProjectFile = await fileService.SaveAsync<ProjectsMaster>(dto.ProjectFiles, "file.dat");
 

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(entity.Adapt<ProjectsMasterDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ProjectsMasterDto dto,
        CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var entity = getResult.Value;
        dto.Adapt(entity);

        if (dto.ProjectResources is not null)
            entity.ProjectResources =
                await fileService.SaveAsync<ProjectsMaster>(dto.ProjectResources, "resource.dat");

        if (dto.ProjectFiles is not null)
            entity.ProjectFile = await fileService.SaveAsync<ProjectsMaster>(dto.ProjectFiles, "file.dat");

        var updateResult = await repository.UpdateAsync(entity, cancellationToken);
        if (!updateResult.IsSuccess) return Result.Failure<bool>(updateResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var entity = getResult.Value;

        if (!string.IsNullOrWhiteSpace(entity.ProjectResources))
        {
            var deleted = fileService.Delete<ProjectsMaster>(entity.ProjectResources, "resource.dat");
            if (!deleted)
                return Result.Failure<bool>(Error.Problem("File.Delete",
                    $"Failed to delete 'resource.dat' for project {id}"));
        }

        if (!string.IsNullOrWhiteSpace(entity.ProjectFile))
        {
            var deleted = fileService.Delete<ProjectsMaster>(entity.ProjectFile,"file.dat");
            if (!deleted)
                return Result.Failure<bool>(Error.Problem("File.Delete",
                    $"Failed to delete 'file.dat' for project {id}"));
        }

        var deleteResult = await repository.DeleteByIdAsync(id, cancellationToken);
        if (!deleteResult.IsSuccess) return Result.Failure<bool>(deleteResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<(FileStream? File, string? ContentType)>> GetProjectFileAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAsync(
            x => x.Id == id && EF.Property<string?>(x, nameof(ProjectsMaster.ProjectFile)) != null, cancellationToken);
        if (result.IsFailure)
            return Result.Failure<(FileStream?, string?)>(result.Error);

        var (stream, ext) = fileService.Get<ProjectsMaster>(result.Value.ProjectFile, "file.dat");

        if (stream is null)
            return Result.Failure<(FileStream?, string?)>(
                Error.NotFound("File", $"Project file not found for ID: {id}"));

        return await Task.FromResult((stream, GetMimeType(ext)));
    }

    public async Task<Result<(FileStream? File, string? ContentType)>> GetProjectResourcesAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAsync(
            x => x.Id == id && EF.Property<string?>(x, nameof(ProjectsMaster.ProjectResources)) != null,
            cancellationToken);
        if (result.IsFailure)
            return Result.Failure<(FileStream?, string?)>(result.Error);

        var (stream, ext) = fileService.Get<ProjectsMaster>(result.Value.ProjectResources, "resource.dat");

        if (stream is null)
            return Result.Failure<(FileStream?, string?)>(Error.NotFound("Resource",
                $"Project resource not found for ID: {id}"));

        return await Task.FromResult((stream, GetMimeType(ext)));
    }

    public async Task<Result<IReadOnlyCollection<ProjectsMasterDto>>> GetByAcademyIdAsync(Guid academyId,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x => x.AcademyDataId == academyId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProjectsMasterDto>>())
            : Result.Failure<IReadOnlyCollection<ProjectsMasterDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ProjectsMasterDto>>> GetByBranchIdAsync(Guid branchId,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x => x.BranchesDataId == branchId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProjectsMasterDto>>())
            : Result.Failure<IReadOnlyCollection<ProjectsMasterDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ProjectsMasterDto>>> GetByDateRangeAsync(DateOnly start, DateOnly end,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x =>
            x.ProjectStart >= start && x.ProjectEnd <= end, cancellationToken);

        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProjectsMasterDto>>())
            : Result.Failure<IReadOnlyCollection<ProjectsMasterDto>>(result.Error);
    }

    public async Task<Result<int>> CountByAcademyAsync(Guid academyId, CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(x => x.AcademyDataId == academyId, cancellationToken);
    }

    private  string? GetMimeType(string? ext)
    {
       return fileService.GetMimeType(ext ?? "");
    }
}