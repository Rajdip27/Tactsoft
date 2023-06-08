using System.ComponentModel.DataAnnotations.Schema;

namespace New_Pratice_Project.Models
{
    public class Site
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
