using Common.Data;
using Common.Results;
using Dtos.System;
using Entities.Models;
using Entities.Models.BasicInformation;
using Entities.Models.System;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.System;

public class TeacherDataLogic(
    IRepository<TeacherData> repository,
    IRepository<BranchData> branchRepo,
    IRepository<CityCode> cityRepo,
    IRepository<GovernorateCode> governorateRepo,
    IRepository<AcademyData> academyRepo,
    IRepository<CountryCode> countryRepo,
    IFileService fileService,
    IUnitOfWork unitOfWork
) : ITeacherData
{
    private readonly IRepository<TeacherData> _repository = repository;

    public async Task<Result<TeacherDataDto>> GetAsync(Guid id, CancellationToken ct = default)
    {
        var result = await _repository.GetByIdAsync(id, ct);
        return result.IsSuccess
            ? result.Value.Adapt<TeacherDataDto>()
            : Result.Failure<TeacherDataDto>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var result = await _repository.GetAllAsync(ct);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<(FileStream? Stream, string? FileName, string? ContentType)>> GetImageAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity.IsFailure)
            return Result.Failure<(FileStream?, string?, string?)>(entity.Error);

        if (string.IsNullOrEmpty(entity.Value.ImageUrl))
            return Result.Failure<(FileStream?, string?, string?)>(Error.NotFound("Image.NotFound", "No image found for this teacher"));

        var (stream, fileName) = fileService.Get<TeacherData>(entity.Value.ImageUrl!);
        if (stream is null || fileName is null)
            return Result.Failure<(FileStream?, string?, string?)>(Error.NotFound("FileNotFound", $"No file found for ID: {id}"));

        var contentType = GetMimeType(Path.GetExtension(fileName));
        return Result.Success((stream, fileName, contentType));
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetNotActiveAsync(CancellationToken ct = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.IsNotActive == true, ct);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByBranchAsync(Guid branchId, CancellationToken ct = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.BranchesDataId == branchId, ct);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByGovernorateAsync(Guid governorateId, CancellationToken ct = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.GovernorateCodeId == governorateId, ct);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<IReadOnlyCollection<TeacherDataDto>>> GetByCityAsync(Guid cityId, CancellationToken ct = default)
    {
        var result = await _repository.GetFilteredAsync(x => x.CityCodeId == cityId, ct);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<TeacherDataDto>>())
            : Result.Failure<IReadOnlyCollection<TeacherDataDto>>(result.Error);
    }

    public async Task<Result<TeacherDataDto>> CreateAsync(TeacherDataDto dto, CancellationToken ct = default)
    {
        var check = await ValidateRelationsAsync(dto, ct);
        if (check.IsFailure) return Result.Failure<TeacherDataDto>(check.Error);

        var entity = dto.Adapt<TeacherData>();
        var result = await _repository.InsertAsync(entity, ct);
        if (result.IsSuccess)
        {
            if (dto.ImageFile is not null)
                entity.ImageUrl =await fileService.SaveAsync<TeacherData>(dto.ImageFile);
        }
        
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(ct);

        return result.IsSuccess
            ? result.Value.Adapt<TeacherDataDto>()
            : Result.Failure<TeacherDataDto>(result.Error);
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, TeacherDataDto dto, CancellationToken ct = default)
    {
        var existing = await _repository.GetByIdAsync(id, ct);
        if (!existing.IsSuccess) return Result.Failure<bool>(existing.Error);

        var check = await ValidateRelationsAsync(dto, ct);
        if (check.IsFailure) return Result.Failure<bool>(check.Error);

        dto.Adapt(existing.Value);

        if (check.IsSuccess)
        {
            if (dto.ImageFile is not null)
            {
                existing.Value.ImageUrl = await fileService.SaveAsync<TeacherData>(dto.ImageFile);
            }
        }
        
        var result = await _repository.UpdateAsync(existing.Value, ct);
        
        if (result.IsSuccess)
            await unitOfWork.SaveChangesAsync(ct);

        return result.IsSuccess ? result.Value : Result.Failure<bool>(result.Error);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _repository.GetByIdAsync(id, ct);

        if (entity.IsFailure)
        {
            return Result.Failure<bool>(Error.NotFound("TeacherData.NotFound",$"There is non teacher has that id {id}"));
        }
        var result = await _repository.DeleteAsync(entity.Value, ct);
        if (result.IsSuccess)
        {
            if (entity.Value.ImageUrl is not null)
            {
                fileService.Delete<TeacherData>(entity.Value.ImageUrl);
            }
            
        }

        await unitOfWork.SaveChangesAsync(ct);

        return result.IsSuccess ? result.Value : Result.Failure<bool>(result.Error);
    }

    private async Task<Result> ValidateRelationsAsync(TeacherDataDto dto, CancellationToken ct)
    {
         
        {
            var exists = await academyRepo.AnyAsync(a=>a.Id == dto.AcademyDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Academy.NotFound", $"There is non academy exists with this Id {dto.AcademyDataId}"));
        }

        if (dto.CountryCodeId is not null)
        {
            var exists= await countryRepo.AnyAsync(c => c.Id == dto.CountryCodeId, ct);
            if(!exists) return Result.Failure(Error.NotFound("Country.NotFound",$"There is non country exists with this Id {dto.CountryCodeId}"));
        }
         
        {
            var exists = await branchRepo.AnyAsync(x => x.Id == dto.BranchesDataId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Branch.NotFound", "Branch ID not found"));
        }

        if (dto.GovernorateCodeId is not null)
        {
            var exists = await governorateRepo.AnyAsync(x => x.Id == dto.GovernorateCodeId, ct);
            if (!exists) return Result.Failure(Error.NotFound("Governorate.NotFound", "Governorate ID not found"));
        }

        if (dto.CityCodeId is not null)
        {
            var exists = await cityRepo.AnyAsync(x => x.Id == dto.CityCodeId, ct);
            if (!exists) return Result.Failure(Error.NotFound("City.NotFound", "City ID not found"));
        }

        return Result.Success();
    }
    private string? GetMimeType(string? ext)
    {
        return fileService.GetMimeType(ext ?? "");
    }
}
