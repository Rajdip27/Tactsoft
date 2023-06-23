using System.ComponentModel;

namespace CasCading_Project.Models
{
    public class Country
    {
        public int Id { get; set; }
        [DisplayName("Country Name")]
        public string CountryName { get; set; } = "";
        public ICollection<State>  State { get; set; }
        public ICollection<StudentInfo>  StudentInfos { get; set; }
    }
}
