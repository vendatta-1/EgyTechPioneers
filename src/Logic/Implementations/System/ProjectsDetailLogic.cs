using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class ProjectsDetailLogic(
    IRepository<ProjectsDetail> repository,
    IRepository<ProjectsMaster> masterRepository,
    IUnitOfWork unitOfWork)
    : IProjectsDetail
{
    public async Task<Result<ProjectsDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<ProjectsDetailDto>())
            : Result.Failure<ProjectsDetailDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ProjectsDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProjectsDetailDto>>())
            : Result.Failure<IReadOnlyCollection<ProjectsDetailDto>>(result.Error);
    }

    public async Task<Result<ProjectsDetailDto>> CreateAsync(ProjectsDetailDto dto, CancellationToken cancellationToken = default)
    {
        var relationCheck = await ValidateRelationsAsync(dto, cancellationToken);
        if (relationCheck.IsFailure) return Result.Failure<ProjectsDetailDto>(relationCheck.Error);

        var entity = dto.Adapt<ProjectsDetail>();
        var insertResult = await repository.InsertAsync(entity, cancellationToken);
        if (insertResult.IsFailure) return Result.Failure<ProjectsDetailDto>(insertResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(insertResult.Value.Adapt<ProjectsDetailDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ProjectsDetailDto dto, CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var relationCheck = await ValidateRelationsAsync(dto, cancellationToken);
        if (relationCheck.IsFailure) return Result.Failure<bool>(relationCheck.Error);

        var entity = getResult.Value;
        dto.Adapt(entity);

        var updateResult = await repository.UpdateAsync(entity, cancellationToken);
        if (updateResult.IsFailure) return Result.Failure<bool>(updateResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var deleteResult = await repository.DeleteByIdAsync(id, cancellationToken);
        if (deleteResult.IsFailure) return Result.Failure<bool>(deleteResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<IReadOnlyCollection<ProjectsDetailDto>>> GetByMasterIdAsync(Guid masterId, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x => x.ProjectsMasterId == masterId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProjectsDetailDto>>())
            : Result.Failure<IReadOnlyCollection<ProjectsDetailDto>>(result.Error);
    }

    private async Task<Result> ValidateRelationsAsync(ProjectsDetailDto dto, CancellationToken ct)
    {
     
        {
            var exists = await masterRepository.AnyAsync(x=>x.Id == dto.ProjectsMasterId, ct);
            if (!exists) return Result.Failure(Error.NotFound("ProjectsMaster.NotFound", "Related master not found"));
        }
        return Result.Success();
    }
}
