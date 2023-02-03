using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace MvcShortProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        public Boolean Ssc { get; set; }
        public Boolean Hsc { get; set; }
        public Boolean Bsc { get; set; }
        public Boolean Msc { get; set; }
        public string Picture { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [ForeignKey("Country")]
        [Display(Name = "Country Name")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Required]
        [ForeignKey("State")]
        [Display(Name = "State Name")]
        public int StateId { get; set; }
        public State State { get; set; }

        [Required]
        [ForeignKey("City")]
        [Display(Name = "City Name")]
        public int CityId { get; set; }
        public City City { get; set; }


    }
}
