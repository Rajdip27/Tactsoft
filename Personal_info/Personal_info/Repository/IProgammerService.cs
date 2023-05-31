using Personal_info.Models;
using Personal_info.Repository.Base;
using Personal_info.ViewModel;

namespace Personal_info.Repository
{
    public interface IProgammerService:IBaseService<Progammer>
    {
        public IList<VmProgrammer> ProgrammerList();
    }
}
