using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;

public interface IAcademyClaseDetail
{
    Task<Result<AcademyClaseDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<AcademyClaseDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<AcademyClaseDetailDto>> CreateAsync(AcademyClaseDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, AcademyClaseDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream? Stream, string? ContentType)>> GetImageByIdAsync(Guid id);

}