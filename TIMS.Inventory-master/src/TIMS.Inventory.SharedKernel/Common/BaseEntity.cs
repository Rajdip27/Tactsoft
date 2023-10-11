using System.ComponentModel.DataAnnotations.Schema;

namespace TIMS.Inventory.SharedKernel.Common;

public abstract class BaseEntity<TId>
{
    private readonly List<DomainEventBase> _domainEvents = new();

    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    public TId? Id { get; set; }

    /// <summary>
    ///     Clears the domain events. This is called when the user clicks on the domain button to cancel the event
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    ///     Registers a domain event. This is used to notify the domain that an event has occurred in the world
    /// </summary>
    /// <param name="domainEvent">The domain event to</param>
    protected void RegisterDomainEvent(DomainEventBase domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}

public abstract class BaseEntity : BaseEntity<Guid>
{
}