using Personal_info.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Personal_info.Models
{
    public class Country:BaseEntity
    {
        [Display(Name = "Country Name")]
        [Required]
        public string CountryName { get; set; }
        public List<State>   States { get; set; }
        public List<Employee> Employees { get; set; }   
    }
}
