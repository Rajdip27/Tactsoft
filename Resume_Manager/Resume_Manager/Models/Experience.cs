using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Resume_Manager.Models.Base;

namespace Resume_Manager.Models
{
    public class Experience:BaseEntity
    {
        [ForeignKey("Applicant")]//very important
        public long ApplicantId { get; set; }
        public  Applicant Applicant { get;  set; } //very important 

        public string? CompanyName { get; set; } = "";
        public string ? Designation { get; set; } = "";
        [Required]
        public int ? YearsWorked { get; set; }

    }
}
