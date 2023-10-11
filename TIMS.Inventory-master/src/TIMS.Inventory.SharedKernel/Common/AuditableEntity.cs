namespace TIMS.Inventory.SharedKernel.Common;

public abstract class AuditableEntity<TId> : BaseEntity<TId>
{
    public virtual DateTimeOffset Created { get; set; }

    public virtual string? CreatedBy { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is active.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }

    public virtual DateTimeOffset LastModified { get; set; }

    public virtual string? LastModifiedBy { get; set; }

    public virtual EntityStatus Status { get; set; }
}

// abstract class
public abstract class AuditableEntity : AuditableEntity<int>
{
}