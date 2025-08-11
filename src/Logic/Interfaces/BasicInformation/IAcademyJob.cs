using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;
public interface IAcademyJob
{
    Task<Result<AcademyJobDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<AcademyJobDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<AcademyJobDto>> CreateAsync(AcademyJobDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, AcademyJobDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}