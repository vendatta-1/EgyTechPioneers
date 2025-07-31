using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IStudentGroup
{
    Task<Result<StudentGroupDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<List<StudentGroupDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<StudentGroupDto>> CreateAsync(StudentGroupDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, StudentGroupDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}