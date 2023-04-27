using Microsoft.AspNetCore.Mvc.Rendering;
using VotingSystem.Models;

namespace Voting_System.Service
{
    public interface IDepartmentService:IBaseService<AspInfoDepartment>
    {
        public IEnumerable<SelectListItem> Dropdown();
    }
}
