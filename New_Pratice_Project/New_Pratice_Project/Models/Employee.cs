using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace New_Pratice_Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
       
        public string Name { get; set; } = "";
      
        public string Address { get; set; } = "";
        
        public string Phone { get; set; } = "";
        [ForeignKey("DepermentId")]
        public int DepermentId { get; set; }
        public Deperment Deperment { get; set; }
        public ICollection<Site>  Sites { get; set; }
    }
}
