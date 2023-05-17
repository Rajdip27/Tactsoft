using Master_Details.Models;
using Master_Details.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details.Service
{
    public interface ICountryService:IBaseService<Country>
    {
        public IEnumerable<SelectListItem> Dropdown();
    }
}
