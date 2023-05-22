using Master_Details_JQure.DatabaseContext;
using Master_Details_JQure.Models;
using Master_Details_JQure.Service.Base;

namespace Master_Details_JQure.Service
{
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
