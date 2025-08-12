using Common.Data;
using Common.Results;
using Dtos.Complaints;
using Entities.Models;
using Entities.Models.BasicInformation;
using Entities.Models.Complaints;
using Entities.Models.System;
using Logic.Interfaces.Complaints;
using Logic.Interfaces.Helpers;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Logic.Implementations.Complaints;

public class ComplaintsStudentLogic(
    IRepository<ComplaintsStudent> repository,
    IRepository<AcademyData> academyRepo,
    IRepository<BranchData> branchRepo,
    IRepository<ComplaintsStatus> statusRepo,
    IRepository<ComplaintsType> typeRepo,
    IRepository<StudentData> studentRepo,
    IFileService fileService,
    IUnitOfWork unitOfWork) : IComplaintsStudent
{
    private readonly IRepository<ComplaintsStudent> _repository = repository;
    private readonly IFileService _fileService = fileService;

    public async Task<Result<ComplaintsStudentDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<ComplaintsStudentDto>())
            : Result.Failure<ComplaintsStudentDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ComplaintsStudentDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ComplaintsStudentDto>>())
            : Result.Failure<IReadOnlyCollection<ComplaintsStudentDto>>(result.Error);
    }

    public async Task<Result<ComplaintsStudentDto>> CreateAsync(ComplaintsStudentDto dto, CancellationToken cancellationToken = default)
    {
        var validate = await ValidateRelationsAsync(dto, cancellationToken);
        if (validate.IsFailure) return Result.Failure<ComplaintsStudentDto>(validate.Error);

        var entity = dto.Adapt<ComplaintsStudent>();

        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<ComplaintsStudentDto>(result.Error);

        if (dto.FilesAttach is not null)
            entity.FilesAttach = await _fileService.SaveAsync<ComplaintsStudent>(dto.FilesAttach);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(result.Value.Adapt<ComplaintsStudentDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, ComplaintsStudentDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        var validate = await ValidateRelationsAsync(dto, cancellationToken);
        if (validate.IsFailure) return Result.Failure<bool>(validate.Error);

        dto.Adapt(existing.Value);

        if (dto.FilesAttach is not null)
            existing.Value.FilesAttach = await _fileService.SaveAsync<ComplaintsStudent>(dto.FilesAttach);

        var updated = await _repository.UpdateAsync(existing.Value, cancellationToken);
        if (updated.IsFailure) return Result.Failure<bool>(updated.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        if (result.IsFailure) return Result.Failure<bool>(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<IReadOnlyCollection<ComplaintsStudentDto>>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.StudentsDataId == studentId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ComplaintsStudentDto>>())
            : Result.Failure<IReadOnlyCollection<ComplaintsStudentDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ComplaintsStudentDto>>> GetByStatusIdAsync(Guid statusId, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.ComplaintsStatusesId == statusId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ComplaintsStudentDto>>())
            : Result.Failure<IReadOnlyCollection<ComplaintsStudentDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<ComplaintsStudentDto>>> GetByDateRangeAsync(DateOnly from, DateOnly to, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.Date >= from && x.Date <= to, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<ComplaintsStudentDto>>())
            : Result.Failure<IReadOnlyCollection<ComplaintsStudentDto>>(result.Error);
    }

    public async Task<Result<int>> CountByStatusAsync(Guid statusId, CancellationToken cancellationToken = default)
    {
        return await _repository.CountAsync(x => x.ComplaintsStatusesId == statusId, cancellationToken);
    }

    public async Task<Result<(byte[]? File, string? ContentType)>> GetAttachmentsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(x=>x.Id == id && x.FilesAttach!=null, cancellationToken);
        if(result.IsFailure)
            return Result.Failure<(byte[]?, string?)>(result.Error);
        var (stream, ext) = _fileService.Get<ComplaintsStudent>(result.Value.FilesAttach);
        if (stream is null) return Result.Failure<(byte[]?, string?)>(Error.NotFound("FileNotFound", $"there is non attachment for this complaints with id: {id}"));

        await using var ms = new MemoryStream();
        await stream.CopyToAsync(ms, cancellationToken);
        return Result.Success(((byte[]?)ms.ToArray(), GetMimeType(ext)));
    }

    private static string? GetMimeType(string? ext)
    {
        if (string.IsNullOrWhiteSpace(ext)) return null;
        return ext.ToLower() switch
        {
            ".pdf" => "application/pdf",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".txt" => "text/plain",
            _ => "application/octet-stream"
        };
    }

    private async Task<Result<bool>> ValidateRelationsAsync(ComplaintsStudentDto dto, CancellationToken ct)
    {
       
        {
            var exists = await academyRepo.AnyAsync(x => x.Id == dto.AcademyDataId, ct);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Relation.Academy", "Academy not found."));
        }
 
        {
            var exists = await branchRepo.AnyAsync(x => x.Id == dto.BranchesDataId, ct);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Relation.Branch", "Branch not found."));
        }

        if (dto.ComplaintsStatusesId is not null)
        {
            var exists = await statusRepo.AnyAsync(x => x.Id == dto.ComplaintsStatusesId, ct);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Relation.Status", "Status not found."));
        }

        if (dto.ComplaintsTypeId is not null)
        {
            var exists = await typeRepo.AnyAsync(x => x.Id == dto.ComplaintsTypeId, ct);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Relation.Type", "Type not found."));
        }
 
        {
            var exists = await studentRepo.AnyAsync(x => x.Id == dto.StudentsDataId, ct);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Relation.Student", "Student not found."));
        }

        return Result.Success(true);
    }
}
