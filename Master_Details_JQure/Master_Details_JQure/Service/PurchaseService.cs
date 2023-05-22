using Master_Details_JQure.DatabaseContext;
using Master_Details_JQure.Models;
using Master_Details_JQure.Service.Base;

namespace Master_Details_JQure.Service
{
    public class PurchaseService : BaseService<Purchase>, IPurchaseService
    {
        private readonly ApplicationDbContext _context;
        public PurchaseService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
