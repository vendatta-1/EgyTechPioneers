using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models;
using Entities.Models.BasicInformation;
using Entities.Models.System;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class SkillDevelopmentLogic(
    IRepository<SkillDevelopment> repository,
    IRepository<BranchData> branchRepo,
    IRepository<AcademyData> academyRepo,
    IFileService fileService,
    IUnitOfWork unitOfWork
) : ISkillDevelopment
{
    public async Task<Result<SkillDevelopmentDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<SkillDevelopmentDto>())
            : Result.Failure<SkillDevelopmentDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<SkillDevelopmentDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<SkillDevelopmentDto>>())
            : Result.Failure<IReadOnlyCollection<SkillDevelopmentDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<SkillDevelopmentDto>>> GetNotActiveAsync(CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x => x.IsNotActive == true, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<SkillDevelopmentDto>>())
            : Result.Failure<IReadOnlyCollection<SkillDevelopmentDto>>(result.Error);
    }

    public async Task<Result<SkillDevelopmentDto>> CreateAsync(SkillDevelopmentDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<SkillDevelopmentDto>(check.Error);

        var entity = dto.Adapt<SkillDevelopment>();

        if (dto.AttachedFiles is not null)
            entity.FilesAttach = await fileService.SaveAsync<SkillDevelopment>(dto.AttachedFiles );

        var insertResult = await repository.InsertAsync(entity, cancellationToken);
        if (insertResult.IsFailure) return Result.Failure<SkillDevelopmentDto>(insertResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(entity.Adapt<SkillDevelopmentDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, SkillDevelopmentDto dto, CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        var entity = getResult.Value;
        dto.Adapt(entity);

        if (dto.AttachedFiles is not null)
            entity.FilesAttach = await fileService.SaveAsync<SkillDevelopment>(dto.AttachedFiles);

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

        if (!string.IsNullOrWhiteSpace(entity.Value.FilesAttach))
        {
            var deleted = fileService.Delete<SkillDevelopment>(entity.Value.FilesAttach);
            if (!deleted)
                return Result.Failure<bool>(Error.Problem("Delete.Failed", $"Error while delete the file for entity: {id}"));
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<(byte[]? File, string? ContentType)>> GetAttachmentsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if(entity.IsFailure)
            return Result.Failure<(byte[]?, string?)>(entity.Error);
        
        var (stream, ext) = fileService.Get<SkillDevelopment>(entity.Value.FilesAttach);
        
        if (stream is null)
            return Result.Failure<(byte[]?, string?)>(Error.NotFound("FileNotFound", $"There is no attachment for this item with ID: {id}"));

        await using var ms = new MemoryStream();
        await stream.CopyToAsync(ms, cancellationToken);

        return Result.Success((ms.ToArray(), GetMimeType(ext)));
    }

    private async Task<Result> ValidateRelationsAsync(SkillDevelopmentDto dto, CancellationToken ct)
    {
         
        {
            var exists = await branchRepo.AnyAsync(x => x.Id == dto.BranchesDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Branch.NotFound", "Branch ID not found"));
        }

        
        {
            var exists = await academyRepo.AnyAsync(x => x.Id == dto.AcademyDataId, ct);
            if(!exists) return Result.Failure(Error.NotFound("Academy.NotFound", "Academy ID not found"));
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
