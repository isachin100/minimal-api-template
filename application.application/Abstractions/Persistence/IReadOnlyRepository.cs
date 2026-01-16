using application.domain.Common.Interfaces;

namespace application.application.Abstractions.Persistence
{
    public interface IReadOnlyRepository<TEntity, TId>
    where TEntity : IEntity<TId>
    where TId : notnull
    {
        Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct = default);
    }
}
