using Personal_info.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Personal_info.Models
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
        public List<Employee> Employees { get; set; }
    }
}
