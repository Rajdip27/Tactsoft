using MediatR;

namespace TIMS.Inventory.SharedKernel.Common;

public abstract class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    //date time variable
}