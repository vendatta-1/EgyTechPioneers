 
using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;

public interface IEduContactResult
{
    Task<Result<EduContactResultDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<EduContactResultDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<EduContactResultDto>> CreateAsync(EduContactResultDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, EduContactResultDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

   
    Task<Result<IReadOnlyCollection<EduContactResultDto>>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<EduContactResultDto>>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken cancellationToken = default);

    Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetAttachmentAsync(Guid id,
        CancellationToken cancellationToken = default);
}
