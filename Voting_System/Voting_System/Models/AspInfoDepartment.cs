using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using VotingSystem.Models.Base;

namespace VotingSystem.Models
{
    public class AspInfoDepartment : BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "DepartmentName")]
        public string   DepartmentName { get; set; }
        public List<AspInfoCategory> AspInfoCategories { get; set; }
    }
}
