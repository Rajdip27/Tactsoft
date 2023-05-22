using Master_Details_JQure.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Master_Details_JQure.Models
{
    public class Country:BaseEntity
    {
        [Required]
        [Display(Name = "Country Name")]
        [StringLength(50)]
        public string CountryName { get; set; }
        public List<State>  States { get; set;}
        public List<Supplier>Suppliers { get; set;}


    }
}
