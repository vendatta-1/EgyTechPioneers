using Common.Results;
using Dtos.Complaints;

namespace Logic.Interfaces.Complaints;

public interface IComplaintsStudent
{
    Task<Result<ComplaintsStudentDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ComplaintsStudentDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<ComplaintsStudentDto>> CreateAsync(ComplaintsStudentDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, ComplaintsStudentDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ComplaintsStudentDto>>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ComplaintsStudentDto>>> GetByStatusIdAsync(Guid statusId, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<ComplaintsStudentDto>>> GetByDateRangeAsync(DateOnly from, DateOnly to, CancellationToken cancellationToken = default);
    Task<Result<int>> CountByStatusAsync(Guid statusId, CancellationToken cancellationToken = default);

    Task<Result<(FileStream? File, string? FileName, string? ContentType)>> GetAttachmentsAsync(Guid id,
        CancellationToken cancellationToken = default);

}