using Common.Results;
using Dtos.System;
using Entities.Models;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class StudentEvaluationLogic(IRepository<StudentEvaluation> repository) : IStudentEvaluation
{
    private readonly IRepository<StudentEvaluation> _repository = repository;

    public async Task<Result<StudentEvaluationDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentEvaluationDto>() : Result.Failure<StudentEvaluationDto>(result.Error);
    }

    public async Task<Result<List<StudentEvaluationDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<List<StudentEvaluationDto>>() : Result.Failure<List<StudentEvaluationDto>>(result.Error);
    }

    public async Task<Result<StudentEvaluationDto>> CreateAsync(StudentEvaluationDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<StudentEvaluation>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentEvaluationDto>() : Result.Failure<StudentEvaluationDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentEvaluationDto dto, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

        dto.Adapt(result.Value);
        return await _repository.UpdateAsync(result.Value, cancellationToken);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}