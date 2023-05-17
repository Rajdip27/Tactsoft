using Master_Details.DataContext;
using Master_Details.Models;
using Master_Details.Service.Base;

namespace Master_Details.Service
{
    public class PurchaseSerivce : BaseService<Purchase>, IPurchaseSerivce
    {
        private readonly ApplicationDbContext _context;
        public PurchaseSerivce(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
