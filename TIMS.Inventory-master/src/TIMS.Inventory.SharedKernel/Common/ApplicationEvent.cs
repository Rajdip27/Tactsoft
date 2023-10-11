namespace TIMS.Inventory.SharedKernel.Common;

public class ApplicationEvent<T, Key> : DomainEventBase
    where T : BaseEntity<Key>, new()
{
    public ApplicationEvent(T item)
    {
        Item = item;
    }

    public T Item { get; }
    //get items
}