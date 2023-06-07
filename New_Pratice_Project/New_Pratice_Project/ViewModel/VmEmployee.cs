using New_Pratice_Project.Models;

namespace New_Pratice_Project.ViewModel
{
    public class VmEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public Nullable<int> depermentId { get; set; }
        public string Deperment { get; set; } 
      

    }
}
