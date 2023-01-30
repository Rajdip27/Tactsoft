using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MVC_CURD.Models
{
    public class Country
    {
        public Country()
        {
            States = new Collection<State>();
            Employees = new Collection<Employee>();

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Country Name")]
        public string CountryName { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
