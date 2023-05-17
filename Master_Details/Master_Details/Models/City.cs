using Master_Details.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details.Models
{
    public class City:BaseEntity
    {
        [Required]
        [Display(Name = "City Name")]
        public string CityName { get; set; } = "";
        [Required]
        [Display(Name = "State")]
        public long StateId { get; set; }
        public State  State { get; set; }
        public IList<Supplier> Suppliers { get; set; }
    }
}
