using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;
public interface IProjectsDetail
{
    Task<Result<ProjectsDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ProjectsDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ProjectsDetailDto>> CreateAsync(ProjectsDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, ProjectsDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ProjectsDetailDto>>> GetByMasterIdAsync(Guid masterId, CancellationToken cancellationToken = default);
}