using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace MvcShortProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string StudentEmail { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string StudentPhone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "DOB")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Gender")]
        public Gender GenderId { get; set; }

       

        public string Picture { get; set; }

        [Required]
        [ForeignKey("Deperment")]
        [Display(Name = "Deperment")]
        public int DepermentId { get; set; }
        public Deperment Deperment { get; set; }

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
