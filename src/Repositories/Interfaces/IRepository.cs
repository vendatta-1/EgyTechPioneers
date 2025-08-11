using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Results;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // Create
        Task<Result<T>> InsertAsync(T entity, CancellationToken cancellationToken = default);
        Task<Result<bool>> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        // Delete
        Task<Result<bool>> DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<Result<bool>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<bool>> DeleteWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        // Read (Single)
        Task<Result<T>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default); 
        Task<Result<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<Result<T>> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<Result<T>> GetLastOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        // Read (Multiple)
        Task<Result<List<T>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<List<T>>> GetAllWithIncludesAsync(Expression<Func<T, object>>[] includes, CancellationToken cancellationToken = default);
        Task<Result<List<T>>> GetFilteredAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);
        Task<Result<List<T>>> GetFilteredAsync(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>>[] includes,
            CancellationToken cancellationToken = default);

        // Read (Paged)
        Task<PagedResult<T>> GetPagedAsync(int pageSize, int currentPage, CancellationToken cancellationToken = default);
        Task<PagedResult<T>> GetPagedAsync(
            int pageSize,
            int currentPage,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            CancellationToken cancellationToken = default);
        Task<PagedResult<T>> GetFilteredPagedAsync(
            Expression<Func<T, bool>> predicate,
            int pageSize,
            int currentPage,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken cancellationToken = default);
        Task<PagedResult<T>> GetFilteredPagedAsync(
            Expression<Func<T, bool>> predicate,
            int pageSize,
            int currentPage,
            Expression<Func<T, object>>[] includes,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken cancellationToken = default);

        // Count
        Task<Result<int>> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        
        //Existence
        
        Task< bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        
    }
}
