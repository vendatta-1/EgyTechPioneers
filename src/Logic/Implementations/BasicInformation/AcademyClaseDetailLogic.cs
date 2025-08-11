using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Logic.Interfaces.BasicInformation;
using Logic.Interfaces.Helpers;
using Mapster;
using Repositories.Interfaces;
using System.Linq.Expressions;
using Common.Data;

namespace Logic.Implementations.BasicInformation;

public class AcademyClaseDetailLogic(
    IRepository<AcademyClaseDetail> repository,
    IRepository<AcademyClaseMaster> masterRepository,
    IRepository<AcademyClaseType> typeRepository,
    IFileService fileService,
    IUnitOfWork unitOfWork
) : IAcademyClaseDetail
{
    private readonly IRepository<AcademyClaseDetail> _repository = repository;
    private readonly IRepository<AcademyClaseMaster> _masterRepository = masterRepository;
    private readonly IRepository<AcademyClaseType> _typeRepository = typeRepository;
    private readonly IFileService _fileService = fileService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<AcademyClaseDetailDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetByIdAsync(id, cancellationToken);
        if (!result.IsSuccess) return Result.Failure<AcademyClaseDetailDto>(result.Error);

        var dto = result.Value.Adapt<AcademyClaseDetailDto>();
        return Result.Success(dto);
    }

    public async Task<Result<IReadOnlyCollection<AcademyClaseDetailDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<IReadOnlyCollection<AcademyClaseDetailDto>>())
            : Result.Failure<IReadOnlyCollection<AcademyClaseDetailDto>>(result.Error);
    }

    public async Task<Result<AcademyClaseDetailDto>> CreateAsync(AcademyClaseDetailDto dto, CancellationToken cancellationToken = default)
    {
        
        if (dto.AcademyClaseMasterId is not null)
        {
            var exists = await _masterRepository.AnyAsync(m => m.Id == dto.AcademyClaseMasterId, cancellationToken);
            if (!exists) return Result.Failure<AcademyClaseDetailDto>(Error.NotFound("Master.NotFound", "AcademyClaseMaster does not exist."));
        }

        if (dto.AcademyClaseTypeId is not null)
        {
            var exists = await _typeRepository.AnyAsync(t => t.Id == dto.AcademyClaseTypeId, cancellationToken);
            if (!exists) return Result.Failure<AcademyClaseDetailDto>(Error.NotFound("Type.NotFound", "AcademyClaseType does not exist."));
        }

        var entity = dto.Adapt<AcademyClaseDetail>();
        var result = await _repository.InsertAsync(entity, cancellationToken);

        if (!result.IsSuccess)
            return Result.Failure<AcademyClaseDetailDto>(result.Error);

        if (dto.Image is not null)
        {
            var imagePath = await _fileService.SaveAsync<AcademyClaseDetail>(dto.Image);
            entity.ImageUrl = imagePath;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(result.Value.Adapt<AcademyClaseDetailDto>());
    }

    public async Task<Result<bool>> UpdateAsync(Guid id, AcademyClaseDetailDto dto, CancellationToken cancellationToken = default)
    {
        var entityResult = await _repository.GetByIdAsync(id, cancellationToken);
        if (!entityResult.IsSuccess) return Result.Failure<bool>(entityResult.Error);

        if (dto.AcademyClaseMasterId is not null)
        {
            var exists = await _masterRepository.AnyAsync(m => m.Id == dto.AcademyClaseMasterId, cancellationToken);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Master.NotFound", "AcademyClaseMaster does not exist."));
        }

        if (dto.AcademyClaseTypeId is not null)
        {
            var exists = await _typeRepository.AnyAsync(t => t.Id == dto.AcademyClaseTypeId, cancellationToken);
            if (!exists) return Result.Failure<bool>(Error.NotFound("Type.NotFound", "AcademyClaseType does not exist."));
        }

        dto.Adapt(entityResult.Value);

        if (dto.Image is not null)
        {
           var imagePath = await _fileService.SaveAsync<AcademyClaseDetail>(dto.Image);
           entityResult.Value.ImageUrl = imagePath;
        }
        
        var updateResult = await _repository.UpdateAsync(entityResult.Value, cancellationToken);
        if (!updateResult.IsSuccess) return Result.Failure<bool>(updateResult.Error);


        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
     
        var entity = await _repository.GetAsync(x=>x.Id == id, cancellationToken);
        if (!entity.IsSuccess) return Result.Failure<bool>(entity.Error);
        
        var result = await _repository.DeleteAsync(entity.Value, cancellationToken);

        if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

        _fileService.Delete<AcademyClaseDetail>(entity.Value.ImageUrl);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(true);
    }

    public async Task<Result<(FileStream? Stream, string? ContentType)>> GetImageByIdAsync(Guid id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id && x.ImageUrl!=null, CancellationToken.None);
        if(entity.IsFailure)
            return Result.Failure<(FileStream?, string?)>(entity.Error);
        
        var (stream, ext) = _fileService.Get<AcademyClaseDetail>(entity.Value.ImageUrl);
        
        var contentType = ext?.ToLower() switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            _ => "application/octet-stream"
        };

        return await Task.FromResult(Result.Success((stream, contentType)));
    }
}
