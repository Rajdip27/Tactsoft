using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using MvcShortProject.Models;

namespace MvcShortProject.Models
{
    public class City
    {
        public City()
        {
            Employees= new Collection<Employee>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [ForeignKey("State")]
        [Display(Name = "State Name")]
        public int StateId { get; set; }
        public State State { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
