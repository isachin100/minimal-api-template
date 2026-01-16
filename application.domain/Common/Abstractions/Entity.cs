using application.domain.Common.Interfaces;

namespace application.domain.Common.Abstractions
{
    public abstract class Entity<TId> : IEntity<TId>
    where TId : notnull
    {
        private List<IDomainEvent>? _domainEvents;

        public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();
        public TId Id { get; protected set; } = default!;

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }
        public override int GetHashCode() => EqualityComparer<TId>.Default.GetHashCode(Id);

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= new();
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() => _domainEvents?.Clear();
    }
}
