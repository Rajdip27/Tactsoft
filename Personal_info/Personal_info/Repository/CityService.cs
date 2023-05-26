using Microsoft.AspNetCore.Mvc.Rendering;
using Personal_info.DatabaseContext;
using Personal_info.Models;
using Personal_info.Repository.Base;

namespace Personal_info.Repository
{
    public class CityService : BaseService<City>, ICityService
    {
        private readonly ApplicationDbContext _context;
        public CityService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.CityName, Value = x.Id.ToString() });
        }
    }
}
