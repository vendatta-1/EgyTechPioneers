using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class StudentEvaluationLogic(
    IRepository<StudentEvaluation> repository,
    IRepository<StudentData> studentRepo,
    IUnitOfWork unitOfWork
) : IStudentEvaluation
{
    private readonly IRepository<StudentEvaluation> _repository = repository;

    public async Task<Result<StudentEvaluationDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? result.Value.Adapt<StudentEvaluationDto>()
            : Result.Failure<StudentEvaluationDto>(result.Error);
    }

    public async Task<Result<List<StudentEvaluationDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? result.Value.Adapt<List<StudentEvaluationDto>>()
            : Result.Failure<List<StudentEvaluationDto>>(result.Error);
    }

    public async Task<Result<StudentEvaluationDto>> CreateAsync(StudentEvaluationDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<StudentEvaluationDto>(check.Error);

        var entity = dto.Adapt<StudentEvaluation>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.IsSuccess
            ? result.Value.Adapt<StudentEvaluationDto>()
            : Result.Failure<StudentEvaluationDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentEvaluationDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        dto.Adapt(existing.Value);
        var result = await _repository.UpdateAsync(existing.Value, cancellationToken);
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.IsSuccess ? result.Value : Result.Failure<bool>(result.Error);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);
        return result.IsSuccess ? result.Value : Result.Failure<bool>(result.Error);
    }

    private async Task<Result> ValidateRelationsAsync(StudentEvaluationDto dto, CancellationToken ct)
    {
        
        {
            var exists = await studentRepo.AnyAsync(x => x.Id == dto.StudentDataId, ct);
            if (!exists)
                return Result.Failure(Error.NotFound("Student.NotFound", "Student ID not found"));
        }

        return Result.Success();
    }
}
