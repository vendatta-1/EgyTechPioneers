using Logic.Interfaces.BasicInformation;
using Logic.Interfaces.Helpers;
using Repositories.Interfaces;
using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Mapster;
using Common.Data;
using Entities.Models.BasicInformation;

namespace Logic.Implementations.BasicInformation;

public class AcademyDataLogic(
    IRepository<AcademyData> repository,
    IFileService fileService,
    IUnitOfWork unitOfWork,
    IRepository<CountryCode> countries,
    IRepository<GovernorateCode> governorates,
    IRepository<CityCode> cities
) : IAcademyData
{
    private readonly IRepository<AcademyData> _repository = repository;
    private readonly IFileService _fileService = fileService;

    public async Task<Result<AcademyDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<AcademyDataDto>())
            : Result.Failure<AcademyDataDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<AcademyDataDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<AcademyDataDto>>())
            : Result.Failure<IReadOnlyCollection<AcademyDataDto>>(result.Error);
    }

    public async Task<Result<AcademyDataDto>> CreateAsync(AcademyDataDto dto,
        CancellationToken cancellationToken = default)
    {
        var validate = await ValidateRelationsAsync(dto, cancellationToken);
        if (validate.IsFailure) return Result.Failure<AcademyDataDto>(validate.Error);

        var entity = dto.Adapt<AcademyData>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<AcademyDataDto>(result.Error);

        if (dto.Image is not null)
            entity.ImageUrl = await _fileService.SaveAsync<AcademyData>(dto.Image);

        if (dto.Attachments is not null)
            entity.AttachFiles = await _fileService.SaveAsync<AcademyData>(dto.Attachments, ".attach");

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(result.Value.Adapt<AcademyDataDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, AcademyDataDto dto,
        CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        var validate = await ValidateRelationsAsync(dto, cancellationToken);
        if (validate.IsFailure) return Result.Failure<bool>(validate.Error);

        dto.Adapt(existing.Value);

        if (dto.Image is not null)
        {
            var imagePath = await _fileService.SaveAsync<AcademyData>(dto.Image);
            existing.Value.ImageUrl = imagePath;
        }

        if (dto.Attachments is not null)
        {
            var path = await _fileService.SaveAsync<AcademyData>(dto.Attachments, ".attach");
            existing.Value.AttachFiles = path;
        }

        var updated = await _repository.UpdateAsync(existing.Value, cancellationToken);
        if (updated.IsFailure) return Result.Failure<bool>(updated.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (!entity.IsSuccess) return Result.Failure<bool>(entity.Error);


        var result = await _repository.DeleteAsync(entity.Value, cancellationToken);

        if (result.IsFailure) return Result.Failure<bool>(result.Error);
        _fileService.Delete<AcademyData>(entity.Value.ImageUrl);
        _fileService.Delete<AcademyData>(entity.Value.AttachFiles, ".attach");

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(result.Value);
    }
    public async Task<Result<(byte[]? file, string? fileName, string? contentType)>> GetImageAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetAsync(x => x.Id == id && x.ImageUrl != null, cancellationToken);
        if (!entity.IsSuccess) return Result.Failure<(byte[]?, string?, string?)>(entity.Error);

        var (stream, fileName) = _fileService.Get<AcademyData>(entity.Value.ImageUrl);
        if (stream is null || fileName is null) return Result.Success<(byte[]?, string?, string?)>((null, null, null));

        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms, cancellationToken);

        var contentType = _fileService.GetMimeType(Path.GetExtension(fileName));
        return Result.Success((ms.ToArray(), fileName, contentType));
    }

    public async Task<Result<(FileStream? file, string? fileName, string? contentType)>> GetAttachmentsAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (!entity.IsSuccess) return Result.Failure<(FileStream?, string?, string?)>(entity.Error);
        if (entity.Value.AttachFiles is null)
            return Result.Failure<(FileStream?, string?, string?)>(Error.NotFound("AttachFiles.NotFound", "No attachments found"));

        var (stream, fileName) = _fileService.Get<AcademyData>(entity.Value.AttachFiles, ".attach");
        if (stream is null || fileName is null)
            return Result.Failure<(FileStream?, string?, string?)>(Error.NotFound("AttachFiles.NotFound", "No attachments found"));

        var contentType = _fileService.GetMimeType(Path.GetExtension(fileName));
        return Result.Success((stream, fileName, contentType));
    }

    private string? GetMimeType(string? extension)
    {
        return _fileService.GetMimeType(extension ?? "");
    }

    private async Task<Result<bool>> ValidateRelationsAsync(AcademyDataDto dto, CancellationToken ct)
    {
        if (dto.CountryCodeId is not null)
        {
            var exists = await countries.AnyAsync(x => x.Id == dto.CountryCodeId, ct);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Relation.CountryCode", "Country does not exist."));
        }

        if (dto.GovernorateCodeId is not null)
        {
            var exists = await governorates.AnyAsync(x => x.Id == dto.GovernorateCodeId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.Governorate", "Governorate does not exist."));
        }

        if (dto.CityCodeId is not null)
        {
            var exists = await cities.AnyAsync(x => x.Id == dto.CityCodeId, ct);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Relation.City", "City does not exist."));
        }

        return Result.Success(true);
    }
}