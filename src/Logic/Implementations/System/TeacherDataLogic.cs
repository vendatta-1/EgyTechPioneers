using Common.Results;
using Dtos.System;
using Entities.Models;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class TeacherDataLogic(IRepository<TeacherData> repository) : ITeacherData
{
    private readonly IRepository<TeacherData> _repository = repository;

    public async Task<Result<TeacherDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? result.Value.Adapt<TeacherDataDto>()
            : Result.Failure<TeacherDataDto>(result.Error);
    }

    public async Task<Result<TeacherDataDto>> CreateAsync(TeacherDataDto dto,
        CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<TeacherData>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        return result.IsSuccess
            ? result.Value.Adapt<TeacherDataDto>()
            : Result.Failure<TeacherDataDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, TeacherDataDto dto,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess)
            return Result.Failure<bool>(result.Error);

        dto.Adapt(result.Value);
        return await _repository.UpdateAsync(result.Value, cancellationToken);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetNotActiveAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.IsNotactive == true, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByBranchAsync(Guid branchId,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.BranchesDataId == branchId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByGovernorateAsync(Guid governorateId,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.GovernorateCodeId == governorateId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByCityAsync(Guid cityId,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.CityCodeId == cityId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }
}