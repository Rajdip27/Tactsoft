using System.ComponentModel;

namespace CasCading_Project.Models
{
    public class State
    {
        public int Id { get; set; }
        [DisplayName("State Name")]
        public string StateName { get; set; } = "";
        public int CountryId { get; set; }
        public Country  Country { get; set; }
        public ICollection<City> City { get; set; }
        public ICollection<StudentInfo>  StudentInfos { get; set; }
    }
}
