namespace jQuery_Ajax_CRUD_Frist.Models.Base
{
    public class BaseEntity:MasterEntity
    {
        public long CreatedBy { get; set; }
        public DateTimeOffset CreatedDateUtc { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDateUtc { get; set; }
    }
}
