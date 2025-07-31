using Common.Results;
using Dtos.System;
using Entities.Models;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class StudentAttendLogic(IRepository<StudentAttend> repository) : IStudentAttend
{
    private readonly IRepository<StudentAttend> _repository = repository;

    public async Task<Result<StudentAttendDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentAttendDto>() : Result.Failure<StudentAttendDto>(result.Error);
    }

    public async Task<Result<List<StudentAttendDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<List<StudentAttendDto>>() : Result.Failure<List<StudentAttendDto>>(result.Error);
    }

    public async Task<Result<StudentAttendDto>> CreateAsync(StudentAttendDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<StudentAttend>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentAttendDto>() : Result.Failure<StudentAttendDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentAttendDto dto, CancellationToken cancellationToken = default)
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