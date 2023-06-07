namespace New_Pratice_Project.Models
{
    public class Deperment
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Employee>  Employees { get; set; }
    }
}
