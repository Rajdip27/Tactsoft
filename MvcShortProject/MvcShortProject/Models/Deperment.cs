using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MvcShortProject.Models
{
    public class Deperment
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Deperment Name")]
        public string Name { get; set; }
    }
}
