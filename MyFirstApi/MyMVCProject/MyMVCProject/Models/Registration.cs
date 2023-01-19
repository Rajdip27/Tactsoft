using System.ComponentModel.DataAnnotations;

namespace MyMVCProject.Models
{
    public class Registration
    {
        public int Id { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        [Display (Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

    }
}
