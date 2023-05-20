using jQuery_Ajax_CRUD_Frist.Models;
using jQuery_Ajax_CRUD_Frist.Service.Base;

namespace jQuery_Ajax_CRUD_Frist.Service
{
    public interface ITransactionService:IBaseService<TransactionModel>
    {
        bool TransactionModelExists(long id);
    }
}
