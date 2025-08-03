using Common.Results;
using Dtos.Complaints;
using Entities.Models.Complaints;
using Logic.Interfaces.Complaints;
using Mapster;
using Repositories.Interfaces;
using Common.Data;
using Entities.Models;

namespace Logic.Implementations.Complaints;

public class ComplaintsStatusLogic(
    IRepository<ComplaintsStatus> repository,
    IRepository<AcademyData> academyRepo,
    IRepository<BranchData> branches,
    IUnitOfWork unitOfWork) : IComplaintsStatus
{
    private readonly IRepository<ComplaintsStatus> _repository = repository;

    public async Task<Result<ComplaintsStatusDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<ComplaintsStatusDto>())
            : Result.Failure<ComplaintsStatusDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ComplaintsStatusDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ComplaintsStatusDto>>())
            : Result.Failure<IReadOnlyCollection<ComplaintsStatusDto>>(result.Error);
    }

    public async Task<Result<ComplaintsStatusDto>> CreateAsync(ComplaintsStatusDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<ComplaintsStatusDto>(check.Error);

        var entity = dto.Adapt<ComplaintsStatus>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure) return Result.Failure<ComplaintsStatusDto>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(result.Value.Adapt<ComplaintsStatusDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ComplaintsStatusDto dto, CancellationToken cancellationToken = default)
    {
        var getResult = await _repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        dto.Adapt(getResult.Value);
        var updateResult = await _repository.UpdateAsync(getResult.Value, cancellationToken);
        if (updateResult.IsFailure) return Result.Failure<bool>(updateResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        if (result.IsFailure) return Result.Failure<bool>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(result.Value);
    }

    private async Task<Result<bool>> ValidateRelationsAsync(ComplaintsStatusDto dto, CancellationToken ct)
    {
        if (dto.AcademyDataId is not null)
        {
            var exists = await academyRepo.AnyAsync(x => x.Id == dto.AcademyDataId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.Company", "Company does not exist."));
        }

        if (dto.BranchesDataId is not null)
        {
            var exists = await branches.AnyAsync(x => x.Id == dto.BranchesDataId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.Branch", "Branch does not exist."));
        }

        return Result.Success(true);
    }
}
