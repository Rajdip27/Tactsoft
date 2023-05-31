using Personal_info.Models.Base;

namespace Personal_info.ViewModel
{
    public class VmProgrammer:MasterEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Age { get; set; }
        public string Office { get; set; }
        public string Salaray { get; set; }
    }
}
