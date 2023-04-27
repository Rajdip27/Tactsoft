using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VotingSystem.Models.Base;

namespace VotingSystem.Models
{
    public class AspInfoCategory : BaseEntity
    {
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        [ForeignKey("AspInfoDepartment")]
        public long DepartmentID { get; set; }
        public AspInfoDepartment  AspInfoDepartment { get; set; }

        public List<AspInfoOption> AspInfoOptions { get; set; }

    }
}
