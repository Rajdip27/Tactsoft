using System.ComponentModel.DataAnnotations;

namespace New_Pratice_Project.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        public int  DepartmentId { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        public string Phone { get; set; }

        //Custom attribute
        public string DepartmentName { get; set; }
        public bool Remember { get; set; }
        public string SiteName { get; set; }
    }
}
