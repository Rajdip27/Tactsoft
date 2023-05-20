using jQuery_Ajax_CRUD_Frist.DatabaseContext;
using jQuery_Ajax_CRUD_Frist.Models;
using jQuery_Ajax_CRUD_Frist.Service.Base;

namespace jQuery_Ajax_CRUD_Frist.Service
{
    public class TransactionService : BaseService<TransactionModel>, ITransactionService
    {
        private readonly ApplicationDbContext _context;
        public TransactionService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool TransactionModelExists(long id)
        {
           var data = _context.Transactions.Any(e => e.Id == id);
            return data;
        }
    }
}
