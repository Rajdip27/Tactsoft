using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MVC_CURD.Models
{
    public class City
    {
        public City()
        {
            Employees = new Collection<Employee>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Enter Your City Name")]
        public string CityName { get; set; }
        [ForeignKey("State")]
        [Display(Name ="State Name")]
        public int StateId { get; set; }
        public State State { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
