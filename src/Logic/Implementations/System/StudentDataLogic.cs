using Common.Results;
using Dtos.System;
using Entities.Models;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;


public class StudentDataLogic(IRepository<StudentData> repository) : IStudentData
{
    private readonly IRepository<StudentData> _repository = repository;

    public async Task<Result<StudentDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentDataDto>() : Result.Failure<StudentDataDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentDataDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentDataDto>>())
            : Result.Failure<IReadOnlyCollection<StudentDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentDataDto>>> GetNotActiveAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.IsNotactive == true, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentDataDto>>())
            : Result.Failure<IReadOnlyCollection<StudentDataDto>>(result.Error);
    }

    public async Task<Result<StudentDataDto>> CreateAsync(StudentDataDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<StudentData>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentDataDto>() : Result.Failure<StudentDataDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentDataDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        dto.Adapt(existing.Value);
        return await _repository.UpdateAsync(existing.Value, cancellationToken);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<Result<StudentDataDto>> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(x => x.StudentEmail == email, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentDataDto>() : Result.Failure<StudentDataDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentDataDto>>> GetByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.StudentGroupId == groupId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentDataDto>>())
            : Result.Failure<IReadOnlyCollection<StudentDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentDataDto>>> GetGraduatedStudentsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.GraduationStatus != null, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentDataDto>>())
            : Result.Failure<IReadOnlyCollection<StudentDataDto>>(result.Error);
    }
}
