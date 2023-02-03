using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MvcShortProject.Models
{
    public class Country
    {
        public Country()
        {
            States = new Collection<State>();
            Employees= new Collection<Employee>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        public ICollection<State> States { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
