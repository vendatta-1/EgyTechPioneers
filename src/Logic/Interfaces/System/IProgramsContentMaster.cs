using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

 
public interface IProgramsContentMaster
{
    Task<Result<ProgramsContentMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ProgramsContentMasterDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ProgramsContentMasterDto>> CreateAsync(ProgramsContentMasterDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, ProgramsContentMasterDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream Stream, string? ContentType)>> GetScientificMaterialAsync(Guid id, CancellationToken cancellationToken = default);
}