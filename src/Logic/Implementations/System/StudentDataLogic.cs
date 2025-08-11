// ✅ UPDATED LOGIC (VALIDATION FOR RELATIONS)

using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models;
using Entities.Models.System;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class StudentDataLogic(
    IRepository<StudentData> repository,
    IRepository<StudentGroup> groupRepo,
    IRepository<ProjectsDetail> projectRepo,
    IRepository<AcademyClaseDetail> classRepo,
    IRepository<BranchData> branchRepo,
    IRepository<CityCode> cityRepo,
    IRepository<GovernorateCode> governorateRepo,
    IRepository<AcademyData> academyRepo,
    IUnitOfWork unitOfWork
) : IStudentData
{
    private readonly IRepository<StudentData> _repository = repository;

    public async Task<Result<StudentDataDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentDataDto>() : Result.Failure<StudentDataDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentDataDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentDataDto>>())
            : Result.Failure<IReadOnlyCollection<StudentDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentDataDto>>> GetNotActiveAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.IsNotActive == true, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentDataDto>>())
            : Result.Failure<IReadOnlyCollection<StudentDataDto>>(result.Error);
    }

    public async Task<Result<StudentDataDto>> CreateAsync(StudentDataDto dto,
        CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<StudentDataDto>(check.Error);

        var entity = dto.Adapt<StudentData>();
        var result = await _repository.InsertAsync(entity, cancellationToken);
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.IsSuccess ? result.Value.Adapt<StudentDataDto>() : Result.Failure<StudentDataDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentDataDto dto,
        CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        dto.Adapt(existing.Value);
        var result = await _repository.UpdateAsync(existing.Value, cancellationToken);
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);
        return result.IsSuccess ? result.Value : Result.Failure<bool>(result.Error);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.DeleteByIdAsync(id, cancellationToken);
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(cancellationToken);
        return result.IsSuccess ? result.Value : Result.Failure<bool>(result.Error);
    }

    public async Task<Result<StudentDataDto>> GetByEmailAsync(string email,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(x => x.StudentEmail == email, cancellationToken);
        return result.IsSuccess ? result.Value.Adapt<StudentDataDto>() : Result.Failure<StudentDataDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentDataDto>>> GetByGroupIdAsync(Guid groupId,
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.StudentGroupId == groupId, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentDataDto>>())
            : Result.Failure<IReadOnlyCollection<StudentDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<StudentDataDto>>> GetGraduatedStudentsAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.GraduationStatus != null, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<StudentDataDto>>())
            : Result.Failure<IReadOnlyCollection<StudentDataDto>>(result.Error);
    }

    private async Task<Result> ValidateRelationsAsync(StudentDataDto dto, CancellationToken ct)
    {
        if (dto.StudentGroupId is not null)
        {
            var exists = await groupRepo.AnyAsync(x => x.Id == dto.StudentGroupId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Group.NotFound", "Group ID not found"));
        }

        if (dto.ProjectsDetailsId is not null)
        {
            var exists = await projectRepo.AnyAsync(x => x.Id == dto.ProjectsDetailsId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Project.NotFound", "Project ID not found"));
        }

        if (dto.AcademyClaseDetailsId is not null)
        {
            var exists = await classRepo.AnyAsync(x => x.Id == dto.AcademyClaseDetailsId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Class.NotFound", "Class ID not found"));
        }

        if (dto.BranchesDataId is not null)
        {
            var exists = await branchRepo.AnyAsync(x => x.Id == dto.BranchesDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Branch.NotFound", "Branch ID not found"));
        }

        if (dto.CityCodeId is not null)
        {
            var exists = await cityRepo.AnyAsync(x => x.Id == dto.CityCodeId, ct);
            if (!exists) return Result.Failure(Error.NotFound("City.NotFound", "City ID not found"));
        }

        if (dto.GovernorateCodeId is not null)
        {
            var exists = await governorateRepo.AnyAsync(x => x.Id == dto.GovernorateCodeId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Governorate.NotFound", "Governorate ID not found"));
        }

        if (dto.TrainingGovernorateId is not null)
        {
            var exists = await governorateRepo.AnyAsync(x => x.Id == dto.TrainingGovernorateId, ct);
            if (!exists)
                return Result.Failure(Error.NotFound("TrainingGovernorate.NotFound",
                    "Training Governorate ID not found"));
        }

        if (dto.AcademyDataId is not null)
        {
            var exists = await academyRepo.AnyAsync(x => x.Id == dto.AcademyDataId, ct);
            if (!exists)
                return Result.Failure(Error.NotFound("Academy.NotFound",
                    $"Academy Data ID not found id: {dto.AcademyDataId}"));
        }

        return Result.Success();
    }
}