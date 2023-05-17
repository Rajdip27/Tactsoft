using Master_Details.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details.Models
{
    public class State:BaseEntity
    {
        [Display(Name = "State Name")]
        [Required]
        public string StateName { get; set; } = "";

        [Display(Name = "Country")]
        public long CountryId { get; set; }

        public Country Country { get; set; }
        public IList<City> Cities { get; set; }
        public IList<Supplier> Suppliers { get; set; }
    }
}
