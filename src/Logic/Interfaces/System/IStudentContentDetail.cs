using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;


public interface IStudentContentDetail
{
    Task<Result<StudentContentDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<StudentContentDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<StudentContentDetailDto>> CreateAsync(StudentContentDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, StudentContentDetailDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetSessionTasksAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetSessionProjectAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetSessionQuizAsync(Guid id, CancellationToken cancellationToken = default);
}