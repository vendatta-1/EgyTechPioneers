using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;
 
public interface IQuestionBankDetail
{
    Task<Result<QuestionBankDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<QuestionBankDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<QuestionBankDetailDto>>> GetByMasterIdAsync(Guid masterId, CancellationToken cancellationToken = default);
    Task<Result<QuestionBankDetailDto>> CreateAsync(QuestionBankDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, QuestionBankDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
