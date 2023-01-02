namespace DDD.Domain.Common
{
    public class Entity
    {
        private readonly List<IDomainEvent> domainEvents;
        public IEnumerable<IDomainEvent> DomainEvents => this.DomainEvents;

        public Entity() 
        {
            this.domainEvents = new();
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            this.domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            this.domainEvents.Remove(domainEvent);
        }

        public void RemoveAllDomainEvents()
        {
            this.domainEvents.Clear();
        }
    }
}
