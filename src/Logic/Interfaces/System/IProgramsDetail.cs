using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IProgramsDetail
{
    Task<Result<ProgramsDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ProgramsDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ProgramsDetailDto>> CreateAsync(ProgramsDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, ProgramsDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}