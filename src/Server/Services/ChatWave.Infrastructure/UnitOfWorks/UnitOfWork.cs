using ChatWave.Application.Persistence.Repository;
using ChatWave.Application.UnitOfWorks;
using ChatWave.Domain.Common;
using ChatWave.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace ChatWave.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private ChatWaveDbContext _context { get; set; }

        public UnitOfWork(ChatWaveDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<T> GetRepository<T>() where T : BaseEntity, new()
          => new BaseRepository<T>(_context);

        public async Task<IDbContextTransaction> BeginTransactionAsync()
            => await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync()
            => await _context.Database.CommitTransactionAsync();

        public async Task RollbackTransactionAsync()
            => await _context.Database.RollbackTransactionAsync();
    }
}
