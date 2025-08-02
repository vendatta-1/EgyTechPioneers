using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class QuestionBankMasterLogic(
    IRepository<QuestionBankMaster> repository,
    IRepository<ProgramsDetail> programsRepository,
    IUnitOfWork unit
) : IQuestionBankMaster
{
    public async Task<Result<QuestionBankMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<QuestionBankMasterDto>())
            : Result.Failure<QuestionBankMasterDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<QuestionBankMasterDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<QuestionBankMasterDto>>())
            : Result.Failure<IReadOnlyCollection<QuestionBankMasterDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<QuestionBankMasterDto>>> GetByProgramIdAsync(Guid programId, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x => x.ProgramsDetailsId == programId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<QuestionBankMasterDto>>())
            : Result.Failure<IReadOnlyCollection<QuestionBankMasterDto>>(result.Error);
    }

    public async Task<Result<QuestionBankMasterDto>> CreateAsync(QuestionBankMasterDto dto, CancellationToken cancellationToken = default)
    {
        var relationCheck = await ValidateRelationsAsync(dto, cancellationToken);
        if (relationCheck.IsFailure) return Result.Failure<QuestionBankMasterDto>(relationCheck.Error);

        var entity = dto.Adapt<QuestionBankMaster>();
        var insert = await repository.InsertAsync(entity, cancellationToken);
        if (!insert.IsSuccess) return Result.Failure<QuestionBankMasterDto>(insert.Error);

        await unit.SaveChangesAsync(cancellationToken);
        return Result.Success(insert.Value.Adapt<QuestionBankMasterDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, QuestionBankMasterDto dto, CancellationToken cancellationToken = default)
    {
        var get = await repository.GetByIdAsync(id, cancellationToken);
        if (!get.IsSuccess) return Result.Failure<bool>(get.Error);

        var relationCheck = await ValidateRelationsAsync(dto, cancellationToken);
        if (relationCheck.IsFailure) return Result.Failure<bool>(relationCheck.Error);

        dto.Adapt(get.Value);
        var update = await repository.UpdateAsync(get.Value, cancellationToken);
        if (!update.IsSuccess) return update;

        await unit.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.DeleteByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

        await unit.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    private async Task<Result> ValidateRelationsAsync(QuestionBankMasterDto dto, CancellationToken ct)
    {
        if (dto.ProgramsDetailsId is not null)
        {
            var exists = await programsRepository.AnyAsync(x => x.Id == dto.ProgramsDetailsId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Relation.ProgramsDetail", "Program not found"));
        }

       
        return Result.Success();
    }
}
