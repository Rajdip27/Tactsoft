using Personal_info.Models.Base;

namespace Personal_info.Models
{
    public class Progammer: BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Age { get; set; }
        public string Office { get; set; }
        public string Salaray { get; set; }
    }
}
