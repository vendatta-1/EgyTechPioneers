using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;

public interface ICityCode
{
    Task<Result<CityCodeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<CityCodeDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<CityCodeDto>> CreateAsync(CityCodeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, CityCodeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}