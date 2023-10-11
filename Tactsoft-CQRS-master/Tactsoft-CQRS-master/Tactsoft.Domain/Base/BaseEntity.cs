namespace Tactsoft.Domain.Base;

public abstract class BaseEntity : MasterEntity
{
    public BaseEntity()
    {
        this.CreatedBy = 1;
        this.CreatedDate = DateTimeOffset.Now;
        this.IsDelete = false;
    }

    public long CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public bool IsDelete { get; set; }
}
