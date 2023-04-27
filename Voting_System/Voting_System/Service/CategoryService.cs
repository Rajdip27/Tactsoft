using Microsoft.AspNetCore.Mvc.Rendering;
using VotingSystem.DatabaseContext;
using VotingSystem.Models;

namespace Voting_System.Service
{
    public class CategoryService : BaseService<AspInfoCategory>, ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x=>new SelectListItem { Text=x.CategoryName,Value=x.Id.ToString()});
        }
    }
}
