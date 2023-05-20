using First_Jqery_Project.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace First_Jqery_Project.Models
{
    public class Student:BaseEntity
    {
        [Required]
        [Display(Name = "Student Name")]
        [StringLength(60)]
        public string StudentName { get; set; }
        [Required]
        [Display(Name = "Father Name")]
        [StringLength(60)]
        public string FatherName { get; set; }
        [Required]
        [Display(Name = "Mother Name")]
        [StringLength(60)]
        public string MotherName { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
       
        public DateTime DateofBirth { get; set; }
    }
}
