using System.ComponentModel.DataAnnotations.Schema;

namespace New_Pratice_Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        [ForeignKey("DepermentId")]
        public int DepermentId { get; set; }
        public Deperment Deperment { get; set; }
    }
}
