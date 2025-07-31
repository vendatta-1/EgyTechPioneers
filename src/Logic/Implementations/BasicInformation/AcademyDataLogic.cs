using Logic.Interfaces.BasicInformation;
using Logic.Interfaces.Helpers;
using Repositories.Interfaces;
using Common.Results;
using Dtos.BasicInformation;
using Entities.Models; 
using Mapster; 
namespace Logic.Implementations.BasicInformation
{
    public class AcademyDataLogic(IRepository<AcademyData> repository, IFileService fileService) : IAcademyData
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

        public async Task<Result<IReadOnlyCollection<AcademyDataDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            return result.IsSuccess
                ? Result.Success(result.Value.Adapt<IReadOnlyCollection<AcademyDataDto>>())
                : Result.Failure<IReadOnlyCollection<AcademyDataDto>>(result.Error);
        }

        public async Task<Result<AcademyDataDto>> CreateAsync(AcademyDataDto dto, CancellationToken cancellationToken = default)
        {
            var entity = dto.Adapt<AcademyData>();
            var result = await _repository.InsertAsync(entity, cancellationToken);
            if (!result.IsSuccess)
                return Result.Failure<AcademyDataDto>(result.Error);

            if (dto.Image is not null)
                await _fileService.SaveAsync<AcademyData>(dto.Image, result.Value.Id);

            if (dto.Attachments is not null)
                await _fileService.SaveAsync<AcademyData>(dto.Attachments, result.Value.Id, ".attach");

            return Result.Success(result.Value.Adapt<AcademyDataDto>());
        }

        public async Task<Result<bool>> UpdateAsync(Guid id, AcademyDataDto dto, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetByIdAsync(id, cancellationToken);
            if (!result.IsSuccess)
                return Result.Failure<bool>(result.Error);

            dto.Adapt(result.Value);

            if (dto.Image is not null)
                await _fileService.SaveAsync<AcademyData>(dto.Image, id);

            if (dto.Attachments is not null)
                await _fileService.SaveAsync<AcademyData>(dto.Attachments, id, ".attach");

            return await _repository.UpdateAsync(result.Value, cancellationToken);
        }

        public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _fileService.Delete<AcademyData>(id);
            _fileService.Delete<AcademyData>(id, ".attach");
            return await _repository.DeleteByIdAsync(id, cancellationToken);
        }

        public async Task<Result<(byte[]? file, string? contentType)>> GetImageAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var (stream, extension) = _fileService.Get<AcademyData>(id);
            if (stream is null) return Result.Success<(byte[]?, string?)>((null, null));
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms, cancellationToken);
            return Result.Success<(byte[]?, string?)>((ms.ToArray(), GetMimeType(extension)));
        }

        public async Task<Result<(byte[]? file, string? contentType)>> GetAttachmentsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var (stream, extension) = _fileService.Get<AcademyData>(id, ".attach");
            if (stream is null) return Result.Success<(byte[]?, string?)>((null, null));
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms, cancellationToken);
            return Result.Success<(byte[]?, string?)>((ms.ToArray(), GetMimeType(extension)));
        }

        private static string? GetMimeType(string? extension)
        {
            return extension?.ToLowerInvariant() switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".pdf" => "application/pdf",
                ".doc" or ".docx" => "application/msword",
                ".xls" or ".xlsx" => "application/vnd.ms-excel",
                _ => "application/octet-stream"
            };
        }
    }
}
