using Common.Results;
using Dtos.System;
using Entities.Models;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;


public class SkillDevelopmentLogic(IRepository<SkillDevelopment> repository, IFileService fileService)
    : ISkillDevelopment
{
    private readonly IRepository<SkillDevelopment> _repository = repository;
    private readonly IFileService _fileService = fileService;

    public async Task<Result<SkillDevelopmentDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? result.Value.Adapt<SkillDevelopmentDto>()
            : Result.Failure<SkillDevelopmentDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<SkillDevelopmentDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<SkillDevelopmentDto>>())
            : Result.Failure<IReadOnlyCollection<SkillDevelopmentDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<SkillDevelopmentDto>>> GetNotActiveAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.IsNotactive == true, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<SkillDevelopmentDto>>())
            : Result.Failure<IReadOnlyCollection<SkillDevelopmentDto>>(result.Error);
    }
   

    public async Task<Result<SkillDevelopmentDto>> CreateAsync(SkillDevelopmentDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<SkillDevelopment>();

        if (dto.FilesAttach is not null)
        {
            var fileName = await _fileService.SaveAsync<SkillDevelopment>(dto.FilesAttach, entity.Id);
            entity.FilesAttach = fileName;
        }

        var result = await _repository.InsertAsync(entity, cancellationToken);
        return result.IsSuccess
            ? result.Value.Adapt<SkillDevelopmentDto>()
            : Result.Failure<SkillDevelopmentDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, SkillDevelopmentDto dto, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

        dto.Adapt(result.Value);

        if (dto.FilesAttach is not null)
        {
            _fileService.Delete<SkillDevelopment>(id);
            var fileName = await _fileService.SaveAsync<SkillDevelopment>(dto.FilesAttach, id);
            result.Value.FilesAttach = fileName;
        }

        return await _repository.UpdateAsync(result.Value, cancellationToken);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _fileService.Delete<SkillDevelopment>(id);
        return await _repository.DeleteByIdAsync(id, cancellationToken);
    }
    public async Task<Result<byte[]>> GetAttachmentAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var exists =await Task.FromResult( _fileService.Exists<SkillDevelopment>(id));
        if (!exists)
            return Result.Failure<byte[]>(Error.NotFound("NotFound", "Attachment not found"));

        var file = _fileService.Read<SkillDevelopment>(id);
        return file ?? Result.Failure<byte[]>(Error.Failure("ReadError", "Could not read the attachment"));
    }
}