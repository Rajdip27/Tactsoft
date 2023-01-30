using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MVC_CURD.Models
{
    public class State
    {
        public State()
        {
            Citys = new Collection<City>();
            Employees = new Collection<Employee>();

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "State Name")]
        public string StateName { get; set; }
        [ForeignKey("Country")]
        [Display(Name ="Country Name")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Citys { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
