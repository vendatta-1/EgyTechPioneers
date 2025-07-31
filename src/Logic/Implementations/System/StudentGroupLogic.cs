using Common.Results;
using Dtos.System;
using Entities.Models;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class StudentGroupLogic(IRepository<StudentGroup> repository) : IStudentGroup
{
    private readonly IRepository<StudentGroup> _repository = repository;

    public async Task<Result<StudentGroupDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentGroupDto>() : Result.Failure<StudentGroupDto>(result.Error);
    }

    public async Task<Result<List<StudentGroupDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<List<StudentGroupDto>>() : Result.Failure<List<StudentGroupDto>>(result.Error);
    }

    public async Task<Result<StudentGroupDto>> CreateAsync(StudentGroupDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<StudentGroup>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentGroupDto>() : Result.Failure<StudentGroupDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentGroupDto dto, CancellationToken cancellationToken = default)
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