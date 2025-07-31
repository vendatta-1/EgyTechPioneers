using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Logic.Interfaces.BasicInformation;
using Logic.Interfaces.System;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.BasicInformation;

 public class AcademyClaseMasterLogic(IRepository<AcademyClaseMaster> repository) : IAcademyClaseMaster
    {
        private readonly IRepository<AcademyClaseMaster> _repository = repository;

        public async Task<Result<AcademyClaseMasterDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetByIdAsync(id, cancellationToken);
            return result.IsSuccess
                ? Result.Success(result.Value.Adapt<AcademyClaseMasterDto>())
                : Result.Failure<AcademyClaseMasterDto>(result.Error);
        }

        public async Task<Result<IReadOnlyCollection<AcademyClaseMasterDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            return result.IsSuccess
                ? Result.Success(result.Value.Adapt<IReadOnlyCollection<AcademyClaseMasterDto>>())
                : Result.Failure<IReadOnlyCollection<AcademyClaseMasterDto>>(result.Error);
        }

        public async Task<Result<AcademyClaseMasterDto>> CreateAsync(AcademyClaseMasterDto dto, CancellationToken cancellationToken = default)
        {
            var entity = dto.Adapt<AcademyClaseMaster>();
            var result = await _repository.InsertAsync(entity, cancellationToken);
            return result.IsSuccess
                ? Result.Success(result.Value.Adapt<AcademyClaseMasterDto>())
                : Result.Failure<AcademyClaseMasterDto>(result.Error);
        }

        public async Task<Result<bool>> UpdateAsync(Guid id, AcademyClaseMasterDto dto, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetByIdAsync(id, cancellationToken);
            if (!result.IsSuccess) return Result.Failure<bool>(result.Error);

            dto.Adapt(result.Value);
            return await _repository.UpdateAsync(result.Value, cancellationToken);
        }

        public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _repository.DeleteByIdAsync(id, cancellationToken);
        }
    }