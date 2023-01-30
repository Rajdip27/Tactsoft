using Microsoft.EntityFrameworkCore;
using Students_Mangmaent_With_Repostory_patten.DatabaseContext;
using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public class CustomerServices : ICustomer
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Create(Customer customer)
        {
           await _dbContext.AddAsync(customer);
            return customer;
        }

        public async Task Delete(int id)
        {
            var result=await _dbContext.Customers.FindAsync(id);
            // _dbContext.Customers.Remove(result);
            _dbContext.Entry(result).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

       
    }
}
