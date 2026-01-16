using application.domain.Common.Abstractions;

namespace application.domain.Common
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
    {
        // Semantic boundary only
    }
}
