using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test_Master_Deitals.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = "";
        [Required]
        [Range(25, 55, ErrorMessage = "Currently, we Have no Positions Vacant for Your Age")]
        [DisplayName("Age in Years")]
        public string Age { get; set; } = "";
        [Required, StringLength(50)]
        public string Qulification { get; set; } = "";
        [Required]
        [Range(1,25, ErrorMessage ="Currently, We Have no Positions Vacant for Your Experience")]
        [DisplayName("Total Experiance in Years")]
        public int TotalExperiance { get; set;}
        public List<Experience> Experiences { get; set;}=new List<Experience>();
    }
}
