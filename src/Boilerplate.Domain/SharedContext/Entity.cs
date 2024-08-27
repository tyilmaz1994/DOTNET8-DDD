namespace Boilerplate.Domain.SharedContext
{
    public abstract class AbstractEntity
    {
        private List<IDomainEvent> _domainEvents;
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public AbstractEntity()
        {
            _domainEvents = [];
        }

        public void Add(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
