using Resume_Manager.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resume_Manager.Models
{
    public class Applicant:BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = "";
        [Required]
        [Range(25, 55, ErrorMessage = "Currently,We Have no Positions Vacant for Your Age")]
        [DisplayName("Age in Years")]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Qualification { get; set; } = "";

        [Required]
        [Range(1, 25, ErrorMessage = "Currently,We Have no Positions Vacant for Your Experience")]
        [DisplayName("Total Experience in Years")]
        public int TotalExperience { get; set; }
       
        public IList<Experience> Experiences { get; set; }=new List<Experience>();
    }
}
