using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CURD.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Enter Your Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Enter Your Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Select Your Gender")]
        public string Gender { get; set; }
        public Boolean Ssc { get; set; }
        public Boolean Hsc { get; set; }
        public Boolean Bsc { get; set; }
        public Boolean Msc { get; set; }
        public string Picture { get; set; }

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
