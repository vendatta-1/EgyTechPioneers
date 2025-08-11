using Common.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using Common;
using Repositories.Data;
using Repositories.Interfaces;


namespace Repositories.Implementations
{
    public class Repository<T>(EducationContext context, ILogger<Repository<T>> logger)
        : IRepository<T> where T : Entity
    {
        private readonly DbSet<T> _dbSet = context.Set<T>() ?? throw new ApplicationException($"No DbSet found for type {typeof(T)}");
        private static readonly ConcurrentDictionary<string, Guid> _cursorStore = new();

        public async Task<Result<int>> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => await _dbSet.CountAsync(predicate, cancellationToken);

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken);
        }

        public async Task<Result<T>> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entry = await _dbSet.AddAsync(entity, cancellationToken);
            return entry.State == EntityState.Added
                ? entity
                : Result.Failure<T>(Error.Failure("InsertFailed", $"Failed to insert entity of type {typeof(T).Name}"));
        }

        public Task<Result<bool>> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entry = _dbSet.Update(entity);
            return Task.FromResult(
                entry.State == EntityState.Modified
                    ? true
                    : Result.Failure<bool>(Error.Failure("UpdateFailed", $"Failed to update entity of type {typeof(T).Name}"))
            );
        }

        public async Task<Result<bool>> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity is null)
                return Result.Failure<bool>(Error.Failure("BadRequest", "Entity is null"));

            var entry = _dbSet.Remove(entity);
            
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<Result<bool>> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync([id], cancellationToken);
            if (entity is null)
                return Result.Failure<bool>(Error.NotFound("NotFound", "Entity not found"));

            var entry = _dbSet.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public async Task<Result<bool>> DeleteWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entities = await _dbSet.Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
            if (!entities.Any())
                return Result.Failure<bool>(Error.NotFound("NotFound", "No matching entities found"));

            _dbSet.RemoveRange(entities);
            return true;
        }

        public async Task<Result<List<T>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Result<List<T>>> GetAllWithIncludesAsync(Expression<Func<T, object>>[] includes, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            foreach (var include in includes)
                query = query.Include(include);

            return await query.AsSplitQuery().ToListAsync(cancellationToken);
        }

        public async Task<Result<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var result = await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
            return result ?? Result.Failure<T>(Error.NotFound("NotFound", "Entity not found"));
        }

        public async Task<Result<T>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _dbSet.FindAsync([id], cancellationToken);
            return result ?? Result.Failure<T>(Error.NotFound("NotFound", "Entity not found"));
        }

        public async Task<Result<List<T>>> GetFilteredAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Result<List<T>>> GetFilteredAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet.Where(predicate).AsNoTracking();
            foreach (var include in includes)
                query = query.Include(include);

            return await query.AsSplitQuery().ToListAsync(cancellationToken);
        }

        public async Task<Result<T>> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var result = await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate, cancellationToken);
            
            return result ?? Result.Failure<T>(Error.NotFound("NotFound", "Entity not found"));
        }

        public async Task<Result<T>> GetLastOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var result = await _dbSet
                .Where(predicate)
                .OrderByDescending(x => x.CreateDateTime ?? DateTime.MinValue)
                .FirstOrDefaultAsync(cancellationToken);
            return result ?? Result.Failure<T>(Error.NotFound("NotFound", "Entity not found"));
        }

        public async Task<PagedResult<T>> GetPagedAsync(int pageSize, int currentPage, CancellationToken cancellationToken = default)
        {
            var total = await _dbSet.CountAsync(cancellationToken);
            
            var items = await _dbSet
                .AsNoTracking()
                .OrderBy(e => e.Id)
                                    .Skip((currentPage - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync(cancellationToken);

            return PagedResult<T>.Success(items.ToArray(), total, pageSize, currentPage);
        }

        public async Task<PagedResult<T>> GetPagedAsync(int pageSize, int currentPage, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, CancellationToken cancellationToken = default)
        {
            var baseQuery = _dbSet.AsNoTracking();
            var total = await baseQuery.CountAsync(cancellationToken);
            var items = await orderBy(baseQuery)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return PagedResult<T>.Success(items.ToArray(), total, pageSize, currentPage);
        }

        public async Task<PagedResult<T>> GetFilteredPagedAsync(Expression<Func<T, bool>> predicate, int pageSize, int currentPage, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default)
        {
            var baseQuery = _dbSet.Where(predicate).AsNoTracking();
            var typeKey = typeof(T).FullName ?? typeof(T).Name;

            if (!_cursorStore.TryGetValue(typeKey, out Guid cursor))
            {
                cursor = await baseQuery.OrderBy(x => x.Id).Select(x => x.Id).FirstOrDefaultAsync(cancellationToken);
                _cursorStore[typeKey] = cursor;
            }

            var total = await baseQuery.CountAsync(cancellationToken);
            var query = (orderBy != null ? orderBy(baseQuery) : baseQuery.OrderBy(e => e.Id))
                .Where(e => e.Id.CompareTo(cursor) >= 0);

            var items = await query.Take(pageSize).ToListAsync(cancellationToken);

            if (items.Any())
                _cursorStore[typeKey] = items.Last().Id;

            return PagedResult<T>.Success(items.ToArray(), total, pageSize, currentPage);
        }

        public async Task<PagedResult<T>> GetFilteredPagedAsync(Expression<Func<T, bool>> predicate, int pageSize, int currentPage, Expression<Func<T, object>>[] includes, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> baseQuery = _dbSet.Where(predicate).AsNoTracking();
            foreach (var include in includes)
                baseQuery = baseQuery.Include(include);

            baseQuery = baseQuery.AsSplitQuery();

            var typeKey = typeof(T).FullName ?? typeof(T).Name;
            if (!_cursorStore.TryGetValue(typeKey, out Guid cursor))
            {
                cursor = await baseQuery.OrderBy(x => x.Id).Select(x => x.Id).FirstOrDefaultAsync(cancellationToken);
                _cursorStore[typeKey] = cursor;
            }

            var total = await baseQuery.CountAsync(cancellationToken);
            var query = (orderBy != null ? orderBy(baseQuery) : baseQuery.OrderBy(e => e.Id))
                .Where(e => e.Id.CompareTo(cursor) >= 0);

            var items = await query.Take(pageSize).ToListAsync(cancellationToken);

            if (items.Any())
                _cursorStore[typeKey] = items.Last().Id;

            return PagedResult<T>.Success(items.ToArray(), total, pageSize, currentPage);
        }
    }
}

 