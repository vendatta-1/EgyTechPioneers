using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IStudentAttend
{
    Task<Result<StudentAttendDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<List<StudentAttendDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<StudentAttendDto>> CreateAsync(StudentAttendDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, StudentAttendDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}