using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models;
using Entities.Models.System;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class QuestionBankDetailLogic(
    IRepository<QuestionBankDetail> repository,
    IRepository<QuestionBankMaster> masterRepository,
    IUnitOfWork unit
) : IQuestionBankDetail
{
    public async Task<Result<QuestionBankDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<QuestionBankDetailDto>())
            : Result.Failure<QuestionBankDetailDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<QuestionBankDetailDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<QuestionBankDetailDto>>())
            : Result.Failure<IReadOnlyCollection<QuestionBankDetailDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<QuestionBankDetailDto>>> GetByMasterIdAsync(Guid masterId,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetFilteredAsync(x => x.QuestionBankMasterId == masterId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<QuestionBankDetailDto>>())
            : Result.Failure<IReadOnlyCollection<QuestionBankDetailDto>>(result.Error);
    }

    public async Task<Result<QuestionBankDetailDto>> CreateAsync(QuestionBankDetailDto dto,
        CancellationToken cancellationToken = default)
    {
        var relationCheck = await ValidateRelationsAsync(dto, cancellationToken);
        if (relationCheck.IsFailure)
            return Result.Failure<QuestionBankDetailDto>(relationCheck.Error);

        var entity = dto.Adapt<QuestionBankDetail>();
        var insert = await repository.InsertAsync(entity, cancellationToken);
        if (!insert.IsSuccess) return Result.Failure<QuestionBankDetailDto>(insert.Error);
        await unit.SaveChangesAsync(cancellationToken);
        return Result.Success(insert.Value.Adapt<QuestionBankDetailDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, QuestionBankDetailDto dto,
        CancellationToken cancellationToken = default)
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

    private async Task<Result> ValidateRelationsAsync(QuestionBankDetailDto dto, CancellationToken ct)
    {
       
        {
            var exists = await masterRepository.AnyAsync(x => x.Id == dto.QuestionBankMasterId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Relation.QuestionBankMaster", "Master not found"));
        }

        return Result.Success();
    }
}