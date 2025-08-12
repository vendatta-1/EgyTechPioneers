using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Logic.Interfaces.BasicInformation;
using Mapster;
using Repositories.Interfaces;
using Common.Data;
using Entities.Models.BasicInformation;

namespace Logic.Implementations.BasicInformation;

public class GovernorateCodeLogic(
    IRepository<GovernorateCode> repository,
    IRepository<CountryCode> countries,
    IUnitOfWork unitOfWork) : IGovernorateCode
{
    private readonly IRepository<GovernorateCode> _repository = repository;

    public async Task<Result<GovernorateCodeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<GovernorateCodeDto>())
            : Result.Failure<GovernorateCodeDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<GovernorateCodeDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<GovernorateCodeDto>>())
            : Result.Failure<IReadOnlyCollection<GovernorateCodeDto>>(result.Error);
    }

    public async Task<Result<GovernorateCodeDto>> CreateAsync(GovernorateCodeDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<GovernorateCodeDto>(check.Error);

        var entity = dto.Adapt<GovernorateCode>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure) return Result.Failure<GovernorateCodeDto>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(result.Value.Adapt<GovernorateCodeDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, GovernorateCodeDto dto, CancellationToken cancellationToken = default)
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

    private async Task<Result<bool>> ValidateRelationsAsync(GovernorateCodeDto dto, CancellationToken ct)
    {
         
        {
            var exists = await countries.AnyAsync(x => x.Id == dto.CountryCodeId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.CountryCode", "Country does not exist."));
        }

        return Result.Success(true);
    }
}
