using ChatWave.Application.Persistence.Repository;
using ChatWave.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace ChatWave.Application.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> GetRepository<T>() where T : BaseEntity, new();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
