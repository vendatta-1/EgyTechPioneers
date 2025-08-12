using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models;
using Entities.Models.BasicInformation;
using Entities.Models.System;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class StudentGroupLogic(
    IRepository<StudentGroup> repository,
    IRepository<AcademyData> academyRepo,
    IRepository<BranchData> branchRepo,
    IRepository<TeacherData> teacherRepo,
    IRepository<AcademyClaseDetail> classRepo,
   
    IUnitOfWork unitOfWork
) : IStudentGroup
{
    private readonly IRepository<StudentGroup> _repository = repository;

    public async Task<Result<StudentGroupDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentGroupDto>() : Result.Failure<StudentGroupDto>(result.Error);
    }

    public async Task<Result<List<StudentGroupDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? result.Value.Adapt<List<StudentGroupDto>>()
            : Result.Failure<List<StudentGroupDto>>(result.Error);
    }

    public async Task<Result<StudentGroupDto>> CreateAsync(StudentGroupDto dto, CancellationToken cancellationToken = default)
    {
        var validation = await ValidateRelationsAsync(dto, cancellationToken);
        if (validation.IsFailure) return Result.Failure<StudentGroupDto>(validation.Error);

        var entity = dto.Adapt<StudentGroup>();
        var result = await _repository.InsertAsync(entity, cancellationToken);

        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.IsSuccess
            ? result.Value.Adapt<StudentGroupDto>()
            : Result.Failure<StudentGroupDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentGroupDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        var validation = await ValidateRelationsAsync(dto, cancellationToken);
        if (validation.IsFailure) return Result.Failure<bool>(validation.Error);

        dto.Adapt(existing.Value);
        var result = await _repository.UpdateAsync(existing.Value, cancellationToken);

        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);

        return result;
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    private async Task<Result> ValidateRelationsAsync(StudentGroupDto dto, CancellationToken ct)
    {
       
        {
            var exists = await academyRepo.AnyAsync(x => x.Id == dto.AcademyDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Academy.NotFound", "Academy not found"));
        }

         
        {
            var exists = await branchRepo.AnyAsync(x => x.Id == dto.BranchDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Branch.NotFound", "Branch not found"));
        }

        if (dto.AcademyClaseDetailsId is not null)
        {
            var exists = await classRepo.AnyAsync(x => x.Id == dto.AcademyClaseDetailsId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Class.NotFound", "Class not found"));
        }

        if (dto.TeacherDataId is not null)
        {
            var exists = await teacherRepo.AnyAsync(x => x.Id == dto.TeacherDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Teacher.NotFound", "Teacher not found"));
        }

        return Result.Success();
    }
}
