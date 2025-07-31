using Common.Results;
using Dtos.BasicInformation;

namespace Logic.Interfaces.BasicInformation;

public interface IAcademyClaseMaster
{
    Task<Result<AcademyClaseMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<AcademyClaseMasterDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<AcademyClaseMasterDto>> CreateAsync(AcademyClaseMasterDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, AcademyClaseMasterDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}