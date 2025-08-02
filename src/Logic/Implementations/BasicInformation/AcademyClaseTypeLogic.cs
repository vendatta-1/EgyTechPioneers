using Common.Data;
using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Logic.Interfaces.BasicInformation;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.BasicInformation;

public class AcademyClaseTypeLogic(IRepository<AcademyClaseType> repository, IUnitOfWork unitOfWork) : IAcademyClaseType
{
    private readonly IRepository<AcademyClaseType> _repository = repository;

    public async Task<Result<AcademyClaseTypeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<AcademyClaseTypeDto>())
            : Result.Failure<AcademyClaseTypeDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<AcademyClaseTypeDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<AcademyClaseTypeDto>>())
            : Result.Failure<IReadOnlyCollection<AcademyClaseTypeDto>>(result.Error);
    }

    public async Task<Result<AcademyClaseTypeDto>> CreateAsync(AcademyClaseTypeDto dto,
        CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<AcademyClaseType>();
        
        var result = await _repository.InsertAsync(entity, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<AcademyClaseTypeDto>())
            : Result.Failure<AcademyClaseTypeDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, AcademyClaseTypeDto dto,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

        dto.Adapt(result.Value);
        var updateResult = await _repository.UpdateAsync(result.Value, cancellationToken);
        if (updateResult.IsFailure)
        {
            return Result.Failure<bool>(updateResult.Error);
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(updateResult.Value);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        
        if (result.IsFailure) return Result.Failure<bool>(result.Error);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(result.Value);
    }
}