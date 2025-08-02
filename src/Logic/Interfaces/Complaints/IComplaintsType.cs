using Common.Results;
using Dtos.Complaints;

namespace Logic.Interfaces.Complaints;

public interface IComplaintsType
{
    Task<Result<ComplaintsTypeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ComplaintsTypeDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ComplaintsTypeDto>> CreateAsync(ComplaintsTypeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, ComplaintsTypeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ComplaintsTypeDto>>> GetByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ComplaintsTypeDto>>> GetByBranchIdAsync(Guid branchId, CancellationToken cancellationToken = default);
    Task<Result<bool>> ExistsByNameAsync(string typeNameL1, CancellationToken cancellationToken = default);
}
