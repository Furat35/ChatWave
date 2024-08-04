using ChatWave.Application.Persistence.Repository;
using ChatWave.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace ChatWave.Infrastructure.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly ChatWaveDbContext _dbContext;
        public BaseRepository(ChatWaveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, List<Expression<Func<T, object>>> includes = null, bool isTracking = false)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (isTracking)
                query = query.AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query;
        }

        public async Task<T> GetByIdAsync(Guid id, List<Expression<Func<T, object>>> includes = null, bool isTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (isTracking) { }
            query = query.AsNoTracking();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes = null, bool isTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (isTracking)
                query = query.AsNoTracking();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> AddAsync(T entity)
        {
            _dbContext.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            entity.IsActive = false;
            _dbContext.Update(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return await query.AnyAsync(predicate);
        }
    }
}
