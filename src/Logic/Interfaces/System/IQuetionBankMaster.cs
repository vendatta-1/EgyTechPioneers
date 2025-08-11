using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IQuestionBankMaster
{
    Task<Result<QuestionBankMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<QuestionBankMasterDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<QuestionBankMasterDto>>> GetByProgramIdAsync(Guid programId, CancellationToken cancellationToken = default);
    Task<Result<QuestionBankMasterDto>> CreateAsync(QuestionBankMasterDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, QuestionBankMasterDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}