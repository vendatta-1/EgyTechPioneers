using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;

public interface IGovernorateCode
{
    Task<Result<GovernorateCodeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<GovernorateCodeDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<GovernorateCodeDto>> CreateAsync(GovernorateCodeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, GovernorateCodeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}