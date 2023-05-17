using Master_Details.Models;
using Master_Details.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details.Service
{
    public interface ICityService:IBaseService<City>
    {
        public IEnumerable<SelectListItem> Dropdown();
    }
}
