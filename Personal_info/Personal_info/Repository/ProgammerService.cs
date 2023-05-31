using Personal_info.DatabaseContext;
using Personal_info.Models;
using Personal_info.Repository.Base;
using Personal_info.ViewModel;

namespace Personal_info.Repository
{
    public class ProgammerService : BaseService<Progammer>, IProgammerService
    {
        private readonly ApplicationDbContext _context;
        public ProgammerService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<VmProgrammer> ProgrammerList()
        {
            var programer=_context.Programs.ToList();
            var model=new List<VmProgrammer>();
            foreach (var programmer in programer)
            {
              var newModel=new VmProgrammer();
                newModel.Name = programmer.Name;
                newModel.Position = programmer.Position;
                newModel.Office=programmer.Office;
                newModel.Salaray=programmer.Salaray;
                newModel.Age=programmer.Age;
                model.Add(newModel);

            }
            return model;
        }
    }
}
