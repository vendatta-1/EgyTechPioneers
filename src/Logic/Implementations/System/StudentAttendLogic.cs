using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models.System;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class StudentAttendLogic(
    IRepository<StudentAttend> repository,
    IRepository<StudentData> studentRepo,
    IUnitOfWork unitOfWork)
    : IStudentAttend
{
    public async Task<Result<StudentAttendDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<StudentAttendDto>())
            : Result.Failure<StudentAttendDto>(result.Error);
    }

    public async Task<Result<List<StudentAttendDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<List<StudentAttendDto>>())
            : Result.Failure<List<StudentAttendDto>>(result.Error);
    }

    public async Task<Result<StudentAttendDto>> CreateAsync(StudentAttendDto dto, CancellationToken cancellationToken = default)
    {
        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<StudentAttendDto>(check.Error);

        var entity = dto.Adapt<StudentAttend>();
        var insertResult = await repository.InsertAsync(entity, cancellationToken);
        if (insertResult.IsFailure) return Result.Failure<StudentAttendDto>(insertResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(entity.Adapt<StudentAttendDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, StudentAttendDto dto, CancellationToken cancellationToken = default)
    {
        var getResult = await repository.GetByIdAsync(id, cancellationToken);
        if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

        var check = await ValidateRelationsAsync(dto, cancellationToken);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        var entity = getResult.Value;
        dto.Adapt(entity);

        var updateResult = await repository.UpdateAsync(entity, cancellationToken);
        if (updateResult.IsFailure) return Result.Failure<bool>(updateResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var deleteResult = await repository.DeleteByIdAsync(id, cancellationToken);
        if (deleteResult.IsFailure) return Result.Failure<bool>(deleteResult.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    private async Task<Result> ValidateRelationsAsync(StudentAttendDto dto, CancellationToken ct)
    {
         
        {
            var exists = await studentRepo.AnyAsync(x => x.Id == dto.StudentDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Student.NotFound", "Student ID not found"));
        }

        return Result.Success();
    }
}
