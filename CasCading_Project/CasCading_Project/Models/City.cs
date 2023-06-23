namespace CasCading_Project.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CtiyName { get; set; } = "";
        public int StateId { get; set; }
        public State  State { get; set; }
        public ICollection<StudentInfo>  StudentInfos { get; set; }

    }
}
