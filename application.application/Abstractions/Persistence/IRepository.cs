using application.domain.Common;

namespace application.application.Abstractions.Persistence
{
    public interface IRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : notnull
    {
        Task<IEnumerable<TAggregate>> GetAllAsync(CancellationToken ct = default);
        Task<TAggregate?> GetByIdAsync(TId id, CancellationToken ct = default);
        Task AddAsync(TAggregate aggregate, CancellationToken ct = default);
        Task RemoveAsync(TAggregate aggregate, CancellationToken ct = default);
    }
}
