using Master_Details_JQure.DatabaseContext;
using Master_Details_JQure.Models;
using Master_Details_JQure.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details_JQure.Service
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
