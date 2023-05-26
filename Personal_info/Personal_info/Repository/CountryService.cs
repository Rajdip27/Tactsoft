using Microsoft.AspNetCore.Mvc.Rendering;
using Personal_info.DatabaseContext;
using Personal_info.Models;
using Personal_info.Repository.Base;

namespace Personal_info.Repository
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
