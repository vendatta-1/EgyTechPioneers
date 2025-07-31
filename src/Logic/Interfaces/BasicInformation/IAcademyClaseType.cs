using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;

 

public interface IAcademyClaseType
{
    Task<Result<AcademyClaseTypeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<AcademyClaseTypeDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<AcademyClaseTypeDto>> CreateAsync(AcademyClaseTypeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, AcademyClaseTypeDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}