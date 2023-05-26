using Microsoft.AspNetCore.Mvc.Rendering;
using Personal_info.DatabaseContext;
using Personal_info.Models;
using Personal_info.Repository.Base;

namespace Personal_info.Repository
{
    public class StateService : BaseService<State>, IStateService
    {
        private readonly ApplicationDbContext _context;

        public StateService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.StateName, Value = x.Id.ToString() });
        }
    }
}
