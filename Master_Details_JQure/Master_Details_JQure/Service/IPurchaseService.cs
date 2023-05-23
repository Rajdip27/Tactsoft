using Master_Details_JQure.Models;
using Master_Details_JQure.Service.Base;

namespace Master_Details_JQure.Service
{
    public interface IPurchaseService:IBaseService<Purchase>
    {
        Task DeleteRangeAsync(Purchase purchase);
        Purchase GetItems(long id);
        Task UpdateRangeAsync(Purchase purchase);
    }
}
