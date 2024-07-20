using ChatWave.Domain.Common;
using System.Linq.Expressions;

namespace ChatWave.Application.Persistence.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes = null, bool isTracking = false);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes = null, bool isTracking = true);
        Task<T> GetByIdAsync(Guid id, List<Expression<Func<T, object>>> includes = null, bool isTracking = true);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
