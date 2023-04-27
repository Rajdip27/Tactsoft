using Microsoft.AspNetCore.Mvc.Rendering;
using VotingSystem.DatabaseContext;
using VotingSystem.Models;

namespace Voting_System.Service
{
    public class DepartmentService : BaseService<AspInfoDepartment>, IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        public DepartmentService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
           return All().Select(x=>new SelectListItem { Text=x.DepartmentName,Value=x.Id.ToString()});
        }
    }
}
