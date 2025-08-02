using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class ProgramsDetailLogic : IProgramsDetail
{
    private readonly IRepository<ProgramsDetail> _repository;
    private readonly IRepository<ProjectsDetail> _projectsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProgramsDetailLogic(
        IRepository<ProgramsDetail> repository,
        IRepository<ProjectsDetail> projectsRepository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _projectsRepository = projectsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProgramsDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<ProgramsDetailDto>())
            : Result.Failure<ProgramsDetailDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ProgramsDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ProgramsDetailDto>>())
            : Result.Failure<IReadOnlyCollection<ProgramsDetailDto>>(result.Error);
    }

    public async Task<Result<ProgramsDetailDto>> CreateAsync(ProgramsDetailDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure)
            return Result.Failure<ProgramsDetailDto>(check.Error);

        var entity = dto.Adapt<ProgramsDetail>();
        var insertResult = await _repository.InsertAsync(entity, cancellationToken);
        if (insertResult.IsFailure)
            return Result.Failure<ProgramsDetailDto>(insertResult.Error);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(insertResult.Value.Adapt<ProgramsDetailDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ProgramsDetailDto dto, CancellationToken cancellationToken = default)
    {
        var getResult = await _repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess)
            return Result.Failure<bool>(getResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure)
            return Result.Failure<bool>(check.Error);

        var entity = getResult.Value;
        dto.Adapt(entity);

        var updateResult = await _repository.UpdateAsync(entity, cancellationToken);
        if (updateResult.IsFailure)
            return Result.Failure<bool>(updateResult.Error);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        if (result.IsFailure)
            return Result.Failure<bool>(result.Error);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    private async Task<Result> ValidateRelationsAsync(ProgramsDetailDto dto, CancellationToken cancellationToken)
    {
        if (dto.ProjectsDetailsId.HasValue)
        {
            var exists = await _projectsRepository.AnyAsync(x => x.Id == dto.ProjectsDetailsId, cancellationToken);
            if (!exists)
                return Result.Failure(Error.NotFound("ProjectsDetails.NotFound", "Related ProjectsDetails entity not found."));
        }

        return Result.Success();
    }
}
