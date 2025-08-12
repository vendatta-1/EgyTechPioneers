using Common.Data;
using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Entities.Models.BasicInformation;
using Logic.Interfaces.BasicInformation;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.BasicInformation;

public class AcademyJobLogic(
    IRepository<AcademyJob> repository,
    IRepository<AcademyData> academies,
    IRepository<BranchData> branches,
    IUnitOfWork unitOfWork) : IAcademyJob
{
    private readonly IRepository<AcademyJob> _repository = repository;

    public async Task<Result<AcademyJobDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<AcademyJobDto>())
            : Result.Failure<AcademyJobDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<AcademyJobDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<AcademyJobDto>>())
            : Result.Failure<IReadOnlyCollection<AcademyJobDto>>(result.Error);
    }

    public async Task<Result<AcademyJobDto>> CreateAsync(AcademyJobDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<AcademyJobDto>(check.Error);

        var entity = dto.Adapt<AcademyJob>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure) return Result.Failure<AcademyJobDto>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(result.Value.Adapt<AcademyJobDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, AcademyJobDto dto, CancellationToken cancellationToken = default)
    {
        var entityResult = await _repository.GetByIdAsync(id, cancellationToken);
        if (!entityResult.IsSuccess) return Result.Failure<bool>(entityResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        dto.Adapt(entityResult.Value);
        var result = await _repository.UpdateAsync(entityResult.Value, cancellationToken);
        if (result.IsFailure) return Result.Failure<bool>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        if (result.IsFailure) return Result.Failure<bool>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    private async Task<Result<bool>> ValidateRelationsAsync(AcademyJobDto dto, CancellationToken ct)
    {
       
        {
            var exists = await academies.AnyAsync(x => x.Id == dto.AcademyDataId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.AcademyData", "Academy does not exist."));
        }

        
        {
            var exists = await branches.AnyAsync(x => x.Id == dto.BranchesDataId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.BranchesData", "Branch does not exist."));
        }

        return Result.Success(true);
    }
}
