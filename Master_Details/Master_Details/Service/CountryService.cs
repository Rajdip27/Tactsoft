using Master_Details.DataContext;
using Master_Details.Models;
using Master_Details.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details.Service
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        private readonly ApplicationDbContext _context;
        public CountryService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.CountryName, Value = x.Id.ToString() });
        }
    }
}
