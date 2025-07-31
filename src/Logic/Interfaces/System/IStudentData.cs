using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IStudentData
{
    Task<Result<StudentDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<StudentDataDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<StudentDataDto>>> GetNotActiveAsync(CancellationToken cancellationToken = default);
    Task<Result<StudentDataDto>> CreateAsync(StudentDataDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, StudentDataDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<StudentDataDto>> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<StudentDataDto>>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<StudentDataDto>>> GetGraduatedStudentsAsync(CancellationToken cancellationToken = default);
}
