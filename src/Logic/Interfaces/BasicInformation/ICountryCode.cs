using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;


public interface ICountryCode
{
    Task<Result<CountryCodeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<CountryCodeDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<CountryCodeDto>> CreateAsync(CountryCodeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, CountryCodeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}