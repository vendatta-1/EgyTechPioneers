using Common.Data;
using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Entities.Models.BasicInformation;
using Logic.Interfaces.BasicInformation;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.BasicInformation;

public class AcademyClaseMasterLogic(
    IRepository<AcademyClaseMaster> repository,
    IRepository<AcademyData> academyRepo,
    IRepository<BranchData> branchRepo,
    IRepository<GovernorateCode> governorateRepo,
    IRepository<CityCode> cityRepo,
    IUnitOfWork unitOfWork
) : IAcademyClaseMaster
{
    private readonly IRepository<AcademyClaseMaster> _repository = repository;

    public async Task<Result<AcademyClaseMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<AcademyClaseMasterDto>())
            : Result.Failure<AcademyClaseMasterDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<AcademyClaseMasterDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<AcademyClaseMasterDto>>())
            : Result.Failure<IReadOnlyCollection<AcademyClaseMasterDto>>(result.Error);
    }

    public async Task<Result<AcademyClaseMasterDto>> CreateAsync(AcademyClaseMasterDto dto, CancellationToken cancellationToken = default)
    {
        var validation = await ValidateForeignKeys(dto, cancellationToken);
        if (!validation.IsSuccess)
            return Result.Failure<AcademyClaseMasterDto>(validation.Error);

        var entity = dto.Adapt<AcademyClaseMaster>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure)
        {
            return Result.Failure<AcademyClaseMasterDto>(result.Error);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<AcademyClaseMasterDto>())
            : Result.Failure<AcademyClaseMasterDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, AcademyClaseMasterDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        var validation = await ValidateForeignKeys(dto, cancellationToken);
        if (!validation.IsSuccess) return Result.Failure<bool>(validation.Error);

        dto.Adapt(existing.Value);
        var result = await _repository.UpdateAsync(existing.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result;
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    private async Task<Result> ValidateForeignKeys(AcademyClaseMasterDto dto, CancellationToken cancellationToken)
    {
        if (!await academyRepo.AnyAsync(x => x.Id == dto.AcademyDataId, cancellationToken))
            return Result.Failure(Error.NotFound("Academy.NotFound", "AcademyDataId not found"));

        if (!await branchRepo.AnyAsync(x => x.Id == dto.BranchesDataId, cancellationToken))
            return Result.Failure(Error.NotFound("Branch.NotFound", "BranchesDataId not found"));

        if (dto.GovernorateCodeId is not null &&
            !await governorateRepo.AnyAsync(x => x.Id == dto.GovernorateCodeId, cancellationToken))
            return Result.Failure(Error.NotFound("Governorate.NotFound", "GovernorateCodeId not found"));

        if (dto.CityCodeId is not null &&
            !await cityRepo.AnyAsync(x => x.Id == dto.CityCodeId, cancellationToken))
            return Result.Failure(Error.NotFound("City.NotFound", "CityCodeId not found"));

        return Result.Success();
    }
}
