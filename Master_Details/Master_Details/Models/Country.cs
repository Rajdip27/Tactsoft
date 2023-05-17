using Master_Details.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details.Models
{
    public class Country:BaseEntity
    {
        [Required]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; } = "";
        public IList<State> States { get; set; }
        public IList<Supplier> Suppliers { get; set; }
    }
}
