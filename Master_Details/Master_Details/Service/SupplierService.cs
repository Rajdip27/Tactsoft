using Master_Details.DataContext;
using Master_Details.Models;
using Master_Details.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details.Service
{
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.SupplierName, Value = x.Id.ToString() });
        }
    }
}
