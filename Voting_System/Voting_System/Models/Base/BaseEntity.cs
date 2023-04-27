namespace VotingSystem.Models.Base
{
    public class BaseEntity : MasterEntity
    {
        public string? EntryBy { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public string? ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
