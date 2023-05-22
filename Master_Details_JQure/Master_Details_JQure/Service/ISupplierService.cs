using Master_Details_JQure.Models;
using Master_Details_JQure.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details_JQure.Service
{
    public interface ISupplierService:IBaseService<Supplier>
    {
        public IEnumerable<SelectListItem> Dropdown();
    }
}
