using application.application.Abstractions.Persistence;
using application.domain.Common;
using application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace application.Infrastructure.Repositories
{
    public abstract class Repository<TAggregate, TId>
    : IRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : notnull
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TAggregate> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TAggregate>();
        }

        public async Task<TAggregate?> GetByIdAsync(
            TId id,
            CancellationToken ct = default)
        {
            return await _dbSet
                .FirstOrDefaultAsync(
                    aggregate => aggregate.Id!.Equals(id),
                    ct);
        }

        public async Task AddAsync(
            TAggregate aggregate,
            CancellationToken ct = default)
        {
            await _dbSet.AddAsync(aggregate, ct);
        }

        public Task RemoveAsync(
            TAggregate aggregate,
            CancellationToken ct = default)
        {
            _dbSet.Remove(aggregate);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TAggregate>> GetAllAsync(CancellationToken ct = default)
        {
           return await _dbSet.ToListAsync(ct);
        }
    }
}
