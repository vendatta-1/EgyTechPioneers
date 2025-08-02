using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;

public interface IBranchData
{
    Task<Result<BranchDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<BranchDataDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<BranchDataDto>> CreateAsync(BranchDataDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, BranchDataDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<BranchDataDto>>> GetByAcademyIdAsync(Guid academyId, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<BranchDataDto>>> GetByGovernorateIdAsync(Guid governorateId, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<BranchDataDto>>> GetByCityIdAsync(Guid cityId, CancellationToken cancellationToken = default);
}