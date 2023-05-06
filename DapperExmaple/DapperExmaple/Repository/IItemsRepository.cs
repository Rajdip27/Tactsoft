using DapperExmaple.Models;

namespace DapperExmaple.Repository
{
    public interface IItemsRepository
    {
        Task<List<Items>> GetAll();
        Task<Items> GetById(int id);
        Task<bool> Add(Items item);
        Task<bool> Update(Items item);
        Task<bool> Delete(int id);
    }
}
