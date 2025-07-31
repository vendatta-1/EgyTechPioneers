using Common.Results;
using Dtos.System;
using Entities.Models;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;
 

public class QuestionBankDetailLogic(IRepository<QuestionBankDetail> repository) : IQuestionBankDetail
{
    private readonly IRepository<QuestionBankDetail> _repository = repository;

    public async Task<Result<QuestionBankDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess ? 
            Result.Success(result.Value.Adapt<QuestionBankDetailDto>()) : 
            Result.Failure<QuestionBankDetailDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<QuestionBankDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<QuestionBankDetailDto>>())
            : Result.Failure<IReadOnlyCollection<QuestionBankDetailDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<QuestionBankDetailDto>>> GetByMasterIdAsync(Guid masterId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.QuestionBankMasterId == masterId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<QuestionBankDetailDto>>())
            : Result.Failure<IReadOnlyCollection<QuestionBankDetailDto>>(result.Error);
    }

    public async Task<Result<QuestionBankDetailDto>> CreateAsync(QuestionBankDetailDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<QuestionBankDetail>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        return result.IsSuccess ? Result.Success(result.Value.Adapt<QuestionBankDetailDto>()) : Result.Failure<QuestionBankDetailDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, QuestionBankDetailDto dto, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

        dto.Adapt(result.Value);
        return await _repository.UpdateAsync(result.Value, cancellationToken);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}
