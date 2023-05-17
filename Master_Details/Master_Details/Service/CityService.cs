using Master_Details.DataContext;
using Master_Details.Models;
using Master_Details.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details.Service
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
