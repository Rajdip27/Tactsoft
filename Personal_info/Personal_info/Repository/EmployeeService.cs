using Personal_info.DatabaseContext;
using Personal_info.Models;
using Personal_info.Repository.Base;

namespace Personal_info.Repository
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
