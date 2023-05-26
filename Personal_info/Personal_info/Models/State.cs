using Personal_info.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Personal_info.Models
{
    public class State:BaseEntity
    {
        [Display(Name = "State Name")]
        [Required]
        public string StateName { get; set; }

        [Display(Name = "Country")]
        public long CountryId { get; set; }

        public Country Country { get; set; }
        public List<City>  Cities { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
