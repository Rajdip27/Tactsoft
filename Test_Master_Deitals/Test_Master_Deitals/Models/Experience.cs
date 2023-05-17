using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Master_Deitals.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        [DisplayName("Comapany Name")]
        public string ComapanyName { get; set; } = "";
        [DisplayName("Designation")]
        public string Designation { get; set; } = "";
        [Required]
        public int YearsWorked { get; set; }
        [Required]
        [DisplayName("Applicant")]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
