using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IStudentEvaluation
{
    Task<Result<StudentEvaluationDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<List<StudentEvaluationDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<StudentEvaluationDto>> CreateAsync(StudentEvaluationDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, StudentEvaluationDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}