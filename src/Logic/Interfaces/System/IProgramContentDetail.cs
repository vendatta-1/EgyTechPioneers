 

using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IProgramsContentDetail
{
    Task<Result<ProgramsContentDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ProgramsContentDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ProgramsContentDetailDto>> CreateAsync(ProgramsContentDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, ProgramsContentDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
 
    Task<Result<(FileStream Stream, string? ContentType)>> GetSessionTasksAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream Stream, string? ContentType)>> GetSessionProjectAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream Stream, string? ContentType)>> GetScientificMaterialAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream Stream, string? ContentType)>> GetSessionQuizAsync(Guid id, CancellationToken cancellationToken = default);
}
