using Microsoft.AspNetCore.Mvc.Rendering;
using Personal_info.Models;
using Personal_info.Repository.Base;

namespace Personal_info.Repository
{
    public interface ICityService:IBaseService<City>
    {
        public IEnumerable<SelectListItem> Dropdown();
       
    }
}
