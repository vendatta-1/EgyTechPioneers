using Common.Results;
using Dtos.Complaints;

namespace Logic.Interfaces.Complaints;


public interface IComplaintsStatus
{
    Task<Result<ComplaintsStatusDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ComplaintsStatusDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ComplaintsStatusDto>> CreateAsync(ComplaintsStatusDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, ComplaintsStatusDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}