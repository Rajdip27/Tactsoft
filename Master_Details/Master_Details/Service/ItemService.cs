using Master_Details.DataContext;
using Master_Details.Models;
using Master_Details.Service.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Master_Details.Service
{
    public class ItemService : BaseService<Item>,IItemService
    {
        private readonly ApplicationDbContext _context;
        public ItemService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.ItemName, Value = x.Id.ToString() });
        }
    }
}
