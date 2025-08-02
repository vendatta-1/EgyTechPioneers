using Common.Data;
using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Logic.Interfaces.BasicInformation;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.BasicInformation;

public class CityCodeLogic(
    IRepository<CityCode> repository,
    IRepository<GovernorateCode> governorates,
    IUnitOfWork unitOfWork
) : ICityCode
{
    private readonly IRepository<CityCode> _repository = repository;

    public async Task<Result<CityCodeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<CityCodeDto>())
            : Result.Failure<CityCodeDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<CityCodeDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<CityCodeDto>>())
            : Result.Failure<IReadOnlyCollection<CityCodeDto>>(result.Error);
    }

    public async Task<Result<CityCodeDto>> CreateAsync(CityCodeDto dto, CancellationToken cancellationToken = default)
    {
        var validationResult = await ValidateRelationsAsync(dto, cancellationToken);
        if (validationResult.IsFailure)
            return Result.Failure<CityCodeDto>(validationResult.Error);

        var entity = dto.Adapt<CityCode>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure) return Result.Failure<CityCodeDto>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(result.Value.Adapt<CityCodeDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, CityCodeDto dto, CancellationToken cancellationToken = default)
    {
        var getResult = await _repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var validationResult = await ValidateRelationsAsync(dto, cancellationToken);
        if (validationResult.IsFailure)
            return Result.Failure<bool>(validationResult.Error);

        dto.Adapt(getResult.Value);
        var result = await _repository.UpdateAsync(getResult.Value, cancellationToken);
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

    private async Task<Result<bool>> ValidateRelationsAsync(CityCodeDto dto, CancellationToken cancellationToken)
    {
        if (dto.GovernorateCodeId is not null)
        {
            var exists = await governorates.AnyAsync(x => x.Id == dto.GovernorateCodeId, cancellationToken);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.Governorate", "Governorate does not exist."));
        }

        return Result.Success(true);
    }
}
