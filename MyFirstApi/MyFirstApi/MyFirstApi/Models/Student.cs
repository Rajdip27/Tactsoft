using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Adress")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
    }
}
