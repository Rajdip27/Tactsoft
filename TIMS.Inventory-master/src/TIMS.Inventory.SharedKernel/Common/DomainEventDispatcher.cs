using MediatR;
using TIMS.Inventory.SharedKernel.Interfaces;

namespace TIMS.Inventory.SharedKernel.Common;

public class DomainEventDispatcher<TId> : IDomainEventDispatcher<TId>
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Dispatches and clears events. This method is called by the framework to notify the framework that events have been
    ///     dispatched and cleared.
    /// </summary>
    /// <param name="entitiesWithEvents">The entities with events to dispatch and clear</param>
    public async Task DispatchAndClearEvents(IEnumerable<BaseEntity<TId>> entitiesWithEvents)
    {
        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.DomainEvents.ToArray();
            entity.ClearDomainEvents();
            foreach (var domainEvent in events) await _mediator.Publish(domainEvent).ConfigureAwait(false);
            // set false
        }
    }
}

public class DomainEventDispatcher : DomainEventDispatcher<int>
{
    public DomainEventDispatcher(IMediator mediator) : base(mediator)
    {
    }
}