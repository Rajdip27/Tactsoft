using Master_Details_JQure.DatabaseContext;
using Master_Details_JQure.Models;
using Master_Details_JQure.Service.Base;

namespace Master_Details_JQure.Service
{
    public class ItemService : BaseService<Item>, IItemService
    {
        private readonly ApplicationDbContext _context;
        public ItemService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
