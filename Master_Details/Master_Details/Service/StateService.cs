using Master_Details.DataContext;
using Master_Details.Models;
using Master_Details.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details.Service
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
