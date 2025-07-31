using Common.Results;
using Dtos.System;
using Entities.Models;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

 
public class QuestionBankMasterLogic(IRepository<QuestionBankMaster> repository) : IQuestionBankMaster
{
    private readonly IRepository<QuestionBankMaster> _repository = repository;

    public async Task<Result<QuestionBankMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess ? Result.Success(result.Value.Adapt<QuestionBankMasterDto>()) : Result.Failure<QuestionBankMasterDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<QuestionBankMasterDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<QuestionBankMasterDto>>())
            : Result.Failure<IReadOnlyCollection<QuestionBankMasterDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<QuestionBankMasterDto>>> GetByProgramIdAsync(Guid programId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.ProgramsDetailsId == programId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<QuestionBankMasterDto>>())
            : Result.Failure<IReadOnlyCollection<QuestionBankMasterDto>>(result.Error);
    }

    public async Task<Result<QuestionBankMasterDto>> CreateAsync(QuestionBankMasterDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<QuestionBankMaster>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        return result.IsSuccess ? Result.Success(result.Value.Adapt<QuestionBankMasterDto>()) : Result.Failure<QuestionBankMasterDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, QuestionBankMasterDto dto, CancellationToken cancellationToken = default)
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
