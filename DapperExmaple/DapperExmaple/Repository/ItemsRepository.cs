using DapperExmaple.Context;
using DapperExmaple.Models;

namespace DapperExmaple.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly ApppDbContext _dbContext;
        public ItemsRepository(ApppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<bool> Add(Items item)
        {
            int rowAffected = await _dbContext.ExecuteAsync("INSERT INTO [Master].[Items]([ItemName],[ItemPrice])VALUES(@ItemName,@ItemPrice)", item);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            int rowAffected = await _dbContext.ExecuteAsync("DELETE FROM [Master].[Items] WHERE ItemId=@Id", new { Id = id });
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Items>> GetAll()
        {
            var items = await _dbContext.QueryAsync<Items>("Select * from [Master].[Items]");
            return items.ToList();
        }

        public async Task<Items> GetById(int id)
        {
            var item = await _dbContext.QueryFirstOrDefaultAsync<Items>("SELECT * FROM [Master].[Items] WHERE ItemId=@Id", new { Id = id });
            return item;
        }

        public async Task<bool> Update(Items item)
        {
            int rowAffected = await _dbContext.ExecuteAsync("UPDATE [Master].[Items] SET [ItemName] = @ItemName,[ItemPrice] = @ItemPrice WHERE ItemId=@ItemId", item);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
