using Master_Details_JQure.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details_JQure.Models
{
    public class City:BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string CityName { get; set; }
        [Required]
        [Display(Name = "State")]
        public long StateId { get; set; }
        public State State { get; set; }

        public List<Supplier>Suppliers { get; set; }
    }
}
