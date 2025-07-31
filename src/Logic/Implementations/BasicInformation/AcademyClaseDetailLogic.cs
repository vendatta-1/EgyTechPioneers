using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Logic.Interfaces.BasicInformation;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.BasicInformation;

public class AcademyClaseDetailLogic(
    IRepository<AcademyClaseDetail> repository,
    IFileService fileService
) : IAcademyClaseDetail
{
    private readonly IRepository<AcademyClaseDetail> _repository = repository;
    private readonly IFileService _fileService = fileService;

    public async Task<Result<AcademyClaseDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<AcademyClaseDetailDto>(result.Error);

        var dto = result.Value.Adapt<AcademyClaseDetailDto>();
        return Result.Success(dto);
    }

    public async Task<Result<IReadOnlyCollection<AcademyClaseDetailDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<AcademyClaseDetailDto>>())
            : Result.Failure<IReadOnlyCollection<AcademyClaseDetailDto>>(result.Error);
    }

    public async Task<Result<AcademyClaseDetailDto>> CreateAsync(AcademyClaseDetailDto dto,
        CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<AcademyClaseDetail>();
        var result = await _repository.InsertAsync(entity, cancellationToken);

        if (!result.IsSuccess)
            return Result.Failure<AcademyClaseDetailDto>(result.Error);

        if (dto.Image is not null)
            await _fileService.SaveAsync<AcademyClaseDetail>(dto.Image, result.Value.Id);

        return Result.Success(result.Value.Adapt<AcademyClaseDetailDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, AcademyClaseDetailDto dto,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

        dto.Adapt(result.Value);
        var updateResult = await _repository.UpdateAsync(result.Value, cancellationToken);

        if (dto.Image is not null)
            await _fileService.SaveAsync<AcademyClaseDetail>(dto.Image, result.Value.Id);

        return updateResult;
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _fileService.Delete<AcademyClaseDetail>(id);
        return await _repository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<(FileStream? Stream, string? ContentType)> GetImageByIdAsync(Guid id)
    {
        var (stream, ext) = _fileService.Get<AcademyClaseDetail>(id);
        var contentType = ext?.ToLower() switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            _ => "application/octet-stream"
        };

        return await Task.FromResult((stream, contentType));
    }
}