using Microsoft.AspNetCore.Mvc.Rendering;
using Personal_info.Models;
using Personal_info.Repository.Base;

namespace Personal_info.Repository
{
    public interface ICountryService:IBaseService<Country>
    {
        public IEnumerable<SelectListItem> Dropdown();
    }
}
