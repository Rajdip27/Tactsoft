using Master_Details_JQure.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details_JQure.Models
{
    public class State:BaseEntity
    {
        [Display(Name = "State Name")]
        [Required]
        public string StateName { get; set; }

        [Display(Name = "Country")]
        public long CountryId { get; set; }

        public Country Country { get; set; }
        public List<Supplier>Suppliers{ get; set; }
    }
}
