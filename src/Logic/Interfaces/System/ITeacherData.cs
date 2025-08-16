using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface ITeacherData
{
    Task<Result<TeacherDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<TeacherDataDto>> CreateAsync(TeacherDataDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, TeacherDataDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetImageAsync(Guid id,
        CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetNotActiveAsync(CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByBranchAsync(Guid branchId,
        CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByGovernorateAsync(Guid governorateId,
        CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByCityAsync(Guid cityId,
        CancellationToken cancellationToken = default);
}