using Common.Results;
using Dtos.System;

namespace Logic.Interfaces.System;


public interface ISkillDevelopment
{
    Task<Result<SkillDevelopmentDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<SkillDevelopmentDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyCollection<SkillDevelopmentDto>>> GetNotActiveAsync(CancellationToken cancellationToken = default);
    Task<Result<SkillDevelopmentDto>> CreateAsync(SkillDevelopmentDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Guid id, SkillDevelopmentDto dto, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetAttachmentsAsync(Guid id,
        CancellationToken cancellationToken = default);

}
