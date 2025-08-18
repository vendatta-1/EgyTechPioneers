using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class ProgramsContentMasterLogic(
    IRepository<ProgramsContentMaster> repository,
    IRepository<ProgramsDetail> programsDetailRepo,
    IFileService fileService,
    IUnitOfWork unitOfWork) : IProgramsContentMaster
{
    public async Task<Result<ProgramsContentMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<ProgramsContentMasterDto>())
            : Result.Failure<ProgramsContentMasterDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ProgramsContentMasterDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProgramsContentMasterDto>>())
            : Result.Failure<IReadOnlyCollection<ProgramsContentMasterDto>>(result.Error);
    }

    public async Task<Result<ProgramsContentMasterDto>> CreateAsync(ProgramsContentMasterDto dto,
        CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<ProgramsContentMasterDto>(check.Error);

        var entity = dto.Adapt<ProgramsContentMaster>();

        if (dto.ScientificMaterial is not null)
        {

            entity.ScientificMaterial = await fileService.SaveAsync<ProgramsContentMaster>(dto.ScientificMaterial);
        }

        var insertResult = await repository.InsertAsync(entity, cancellationToken);
        if (insertResult.IsFailure) return Result.Failure<ProgramsContentMasterDto>(insertResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(entity.Adapt<ProgramsContentMasterDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ProgramsContentMasterDto dto,
        CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        var entity = getResult.Value;
        dto.Adapt(entity);

        if (dto.ScientificMaterial is not null)
        {
            fileService.HardDelete<ProgramsContentMaster>(entity.ScientificMaterial);
            entity.ScientificMaterial = await fileService.SaveAsync<ProgramsContentMaster>(dto.ScientificMaterial);
        }

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
        if (!string.IsNullOrWhiteSpace(entity.Value.ScientificMaterial))
        {
            var deleted = fileService.HardDelete<ProgramsContentMaster>(entity.Value.ScientificMaterial);
            if (!deleted)
            {
                return Result.Failure<bool>(Error.Problem("Delete.Failed",
                    $"Error while delete the file for entity: {id}"));
            }
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<(FileStream Stream, string? FileName, string? ContentType)>> GetScientificMaterialAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if (entity.IsFailure)
            return Result.Failure<(FileStream, string?, string?)>(entity.Error);

        var (stream, fileName) = fileService.Get<ProgramsContentMaster>(entity.Value.ScientificMaterial!);
        if (stream is null || fileName is null)
            return Result.Failure<(FileStream, string?, string?)>(Error.NotFound("FileNotFound",
                $"No material for session with ID: {id}"));

        var contentType = GetMimeType(Path.GetExtension(fileName));
        return Result.Success((stream, fileName, contentType));
    }

    private string? GetMimeType(string? ext)
    {
        return fileService.GetMimeType(ext ?? "application/octet-stream");
    }

    private async Task<Result> ValidateRelationsAsync(ProgramsContentMasterDto dto, CancellationToken ct)
    {
        if (dto.ProgramsDetailsId is not null)
        {
            var exists = await programsDetailRepo.AnyAsync(x => x.Id == dto.ProgramsDetailsId, ct);
            if (!exists)
                return Result.Failure(Error.NotFound("ProgramsDetails.NotFound", "ProgramsDetails ID not found"));
        }

        return Result.Success();
    }
}