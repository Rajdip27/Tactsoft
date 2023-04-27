using Microsoft.AspNetCore.Mvc.Rendering;
using VotingSystem.Models;

namespace Voting_System.Service
{
    public interface ICategoryService:IBaseService<AspInfoCategory>
    {
        public IEnumerable<SelectListItem> Dropdown();
    }
}
