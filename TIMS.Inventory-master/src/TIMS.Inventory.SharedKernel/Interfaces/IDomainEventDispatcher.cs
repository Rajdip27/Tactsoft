using TIMS.Inventory.SharedKernel.Common;

namespace TIMS.Inventory.SharedKernel.Interfaces;

public interface IDomainEventDispatcher<TId>
{
    Task DispatchAndClearEvents(IEnumerable<BaseEntity<TId>> entitiesWithEvents);
}