using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Logic.Interfaces.BasicInformation;
using Mapster;
using Repositories.Interfaces;
using Common.Data;

namespace Logic.Implementations.BasicInformation;

public class BranchDataLogic(
    IRepository<BranchData> repository,
    IRepository<AcademyData> academies,
    IRepository<CountryCode> countries,
    IRepository<GovernorateCode> governorates,
    IRepository<CityCode> cities,
    IUnitOfWork unitOfWork
) : IBranchData
{
    private readonly IRepository<BranchData> _repository = repository;

    public async Task<Result<BranchDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<BranchDataDto>())
            : Result.Failure<BranchDataDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<BranchDataDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<BranchDataDto>>())
            : Result.Failure<IReadOnlyCollection<BranchDataDto>>(result.Error);
    }

    public async Task<Result<BranchDataDto>> CreateAsync(BranchDataDto dto, CancellationToken cancellationToken = default)
    {
        var validation = await ValidateRelationsAsync(dto, cancellationToken);
        if (validation.IsFailure) return Result.Failure<BranchDataDto>(validation.Error);

        var entity = dto.Adapt<BranchData>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure) return Result.Failure<BranchDataDto>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(result.Value.Adapt<BranchDataDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, BranchDataDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (existing.IsFailure) return Result.Failure<bool>(existing.Error);

        var validation = await ValidateRelationsAsync(dto, cancellationToken);
        if (validation.IsFailure) return Result.Failure<bool>(validation.Error);

        dto.Adapt(existing.Value);
        var updated = await _repository.UpdateAsync(existing.Value, cancellationToken);
        if (updated.IsFailure) return Result.Failure<bool>(updated.Error);

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

    public async Task<Result<IReadOnlyCollection<BranchDataDto>>> GetByAcademyIdAsync(Guid academyId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(b => b.AcademyDataId == academyId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<BranchDataDto>>())
            : Result.Failure<IReadOnlyCollection<BranchDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<BranchDataDto>>> GetByGovernorateIdAsync(Guid governorateId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(b => b.GovernorateCodeId == governorateId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<BranchDataDto>>())
            : Result.Failure<IReadOnlyCollection<BranchDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<BranchDataDto>>> GetByCityIdAsync(Guid cityId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(b => b.CityCodeId == cityId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<BranchDataDto>>())
            : Result.Failure<IReadOnlyCollection<BranchDataDto>>(result.Error);
    }

    private async Task<Result<bool>> ValidateRelationsAsync(BranchDataDto dto, CancellationToken ct)
    {
        if (dto.AcademyDataId is not null)
        {
            var exists = await academies.AnyAsync(x => x.Id == dto.AcademyDataId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.AcademyData", "Academy does not exist."));
        }

        if (dto.CountryCodeId is not null)
        {
            var exists = await countries.AnyAsync(x => x.Id == dto.CountryCodeId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.Country", "Country does not exist."));
        }

        if (dto.GovernorateCodeId is not null)
        {
            var exists = await governorates.AnyAsync(x => x.Id == dto.GovernorateCodeId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.Governorate", "Governorate does not exist."));
        }

        if (dto.CityCodeId is not null)
        {
            var exists = await cities.AnyAsync(x => x.Id == dto.CityCodeId, ct);
            if (!exists)
                return Result.Failure<bool>(Error.NotFound("Relation.City", "City does not exist."));
        }

        return Result.Success(true);
    }
}
