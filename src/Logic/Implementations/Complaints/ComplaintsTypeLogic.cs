using Common.Results;
using Dtos.Complaints;
using Entities.Models.Complaints;
using Logic.Interfaces.Complaints;
using Mapster;
using Repositories.Interfaces;
using Entities.Models;
using Common.Data;

namespace Logic.Implementations.Complaints;

public class ComplaintsTypeLogic : IComplaintsType
{
    private readonly IRepository<ComplaintsType> _repository;
    private readonly IRepository<AcademyData> _academyRepo;
    private readonly IRepository<BranchData> _branchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ComplaintsTypeLogic(
        IRepository<ComplaintsType> repository,
        IRepository<AcademyData> academyRepo,
        IRepository<BranchData> branchRepository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _academyRepo = academyRepo;
        _branchRepository = branchRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ComplaintsTypeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<ComplaintsTypeDto>())
            : Result.Failure<ComplaintsTypeDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ComplaintsTypeDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ComplaintsTypeDto>>())
            : Result.Failure<IReadOnlyCollection<ComplaintsTypeDto>>(result.Error);
    }

    public async Task<Result<ComplaintsTypeDto>> CreateAsync(ComplaintsTypeDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<ComplaintsTypeDto>(check.Error);

        var entity = dto.Adapt<ComplaintsType>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsFailure) return Result.Failure<ComplaintsTypeDto>(result.Error);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(result.Value.Adapt<ComplaintsTypeDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ComplaintsTypeDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        dto.Adapt(existing.Value);
        var updateResult = await _repository.UpdateAsync(existing.Value, cancellationToken);
        if (updateResult.IsFailure) return Result.Failure<bool>(updateResult.Error);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        if (result.IsFailure) return Result.Failure<bool>(result.Error);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<IReadOnlyCollection<ComplaintsTypeDto>>> GetByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.AcademyDataId == companyId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ComplaintsTypeDto>>())
            : Result.Failure<IReadOnlyCollection<ComplaintsTypeDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ComplaintsTypeDto>>> GetByBranchIdAsync(Guid branchId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.BranchesDataId == branchId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ComplaintsTypeDto>>())
            : Result.Failure<IReadOnlyCollection<ComplaintsTypeDto>>(result.Error);
    }

    public async Task<Result<bool>> ExistsByNameAsync(string typeNameL1, CancellationToken cancellationToken = default)
    {
        var exists = await _repository.AnyAsync(x => x.TypeNameL1 == typeNameL1, cancellationToken);
        return Result.Success(exists);
    }

    private async Task<Result> ValidateRelationsAsync(ComplaintsTypeDto dto, CancellationToken cancellationToken)
    {
        if (dto.AcademyDataId is not null)
        {
            var exists = await _academyRepo.AnyAsync(x => x.Id == dto.AcademyDataId, cancellationToken);
            if (!exists) return Result.Failure(Error.NotFound("CompanyData.NotFound", $"Company ID {dto.AcademyDataId} not found"));
        }

        if (dto.BranchesDataId is not null)
        {
            var exists = await _branchRepository.AnyAsync(x => x.Id == dto.BranchesDataId, cancellationToken);
            if (!exists) return Result.Failure(Error.NotFound("BranchData.NotFound", $"Branch ID {dto.BranchesDataId} not found"));
        }

        return Result.Success();
    }
}
