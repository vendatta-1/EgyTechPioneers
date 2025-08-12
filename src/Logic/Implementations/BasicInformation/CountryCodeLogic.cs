using Common.Data;
using Common.Results;
using Dtos.BasicInformation;
using Entities.Models;
using Entities.Models.BasicInformation;
using Logic.Interfaces.BasicInformation;
using Mapster;
using Repositories.Interfaces;

namespace Logic.Implementations.BasicInformation
{
    public class CountryCodeLogic(IRepository<CountryCode> repository, IUnitOfWork unitOfWork) : ICountryCode
    {
        private readonly IRepository<CountryCode> _repository = repository;

        public async Task<Result<CountryCodeDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetByIdAsync(id, cancellationToken);
            return result.IsSuccess
                ? Result.Success(result.Value.Adapt<CountryCodeDto>())
                : Result.Failure<CountryCodeDto>(result.Error);
        }

        public async Task<Result<IReadOnlyCollection<CountryCodeDto>>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            return result.IsSuccess
                ? Result.Success(result.Value.Adapt<IReadOnlyCollection<CountryCodeDto>>())
                : Result.Failure<IReadOnlyCollection<CountryCodeDto>>(result.Error);
        }

        public async Task<Result<CountryCodeDto>> CreateAsync(CountryCodeDto dto,
            CancellationToken cancellationToken = default)
        {
            var entity = dto.Adapt<CountryCode>();
            var result = await _repository.InsertAsync(entity, cancellationToken);
            if (result.IsSuccess)
            {
                await unitOfWork.SaveChangesAsync(cancellationToken);
                
            }
            return result.IsSuccess
                ? Result.Success(result.Value.Adapt<CountryCodeDto>())
                : Result.Failure<CountryCodeDto>(result.Error);
        }

        public async Task<Result<bool>> UpdateAsync(Guid id, CountryCodeDto dto,
            CancellationToken cancellationToken = default)
        {
            var getResult = await _repository.GetByIdAsync(id, cancellationToken);
            if (!getResult.IsSuccess) return Result.Failure<bool>(getResult.Error);

            dto.Adapt(getResult.Value);
            
            var result = await _repository.UpdateAsync(getResult.Value, cancellationToken);
            
            if (!result.IsSuccess) return Result.Failure<bool>(result.Error);
            
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return result;
        }

        public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.DeleteByIdAsync(id, cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure<bool>(result.Error);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}