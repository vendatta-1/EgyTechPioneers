using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IProjectsMaster
{
    Task<Result<ProjectsMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ProjectsMasterDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ProjectsMasterDto>> CreateAsync(ProjectsMasterDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, ProjectsMasterDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
 
    Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetProjectFileAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetProjectResourcesAsync(Guid id, CancellationToken cancellationToken = default);
    
    public Task<Result<IReadOnlyCollection<ProjectsMasterDto>>> GetByAcademyIdAsync(Guid academyId, CancellationToken cancellationToken = default);
    public Task<Result<IReadOnlyCollection<ProjectsMasterDto>>> GetByBranchIdAsync(Guid branchId, CancellationToken cancellationToken = default);
    public Task<Result<IReadOnlyCollection<ProjectsMasterDto>>> GetByDateRangeAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken = default);
    public Task<Result<int>> CountByAcademyAsync(Guid academyId, CancellationToken cancellationToken = default);

}
