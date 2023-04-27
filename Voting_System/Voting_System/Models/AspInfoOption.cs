using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VotingSystem.Models.Base;

namespace VotingSystem.Models
{
    public class AspInfoOption : BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Option Name")]
        public string  OptionName { get; set; }

        [ForeignKey("AspInfoCategory")]
        [System.ComponentModel.DataAnnotations.Required]
        [Display (Name = "Category Name")]
        public long CategoryId { get; set; }

        public AspInfoCategory  Category { get; set; }
    }
}
