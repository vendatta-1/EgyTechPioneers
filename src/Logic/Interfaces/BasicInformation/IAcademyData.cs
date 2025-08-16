using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;

public interface IAcademyData
{
    Task<Result<AcademyDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<AcademyDataDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<AcademyDataDto>> CreateAsync(AcademyDataDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, AcademyDataDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(byte[]? file, string? contentType)>> GetImageAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream? file, string? contentType)>> GetAttachmentsAsync(Guid id, CancellationToken cancellationToken = default);
}