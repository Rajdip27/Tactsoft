using CrudOperation.Models;
using CrudOperationAllFrom.Database;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationAllFrom.Service
{
    public class CountryService : ICountry
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Country> Create(Country city)
        {
           await _dbContext.AddAsync(city);
            return city;
        }

        public async Task Delete(int id)
        {
           var Result = await _dbContext.Cities.FindAsync(id);
            _dbContext.Entry(Result).State=EntityState.Deleted;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _dbContext.Countries.ToListAsync();
        }

        public async Task<Country> GetById(int id)
        {
            return await _dbContext.Countries.FindAsync(id);
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task<Country> Update(Country city)
        {
           _dbContext.Entry(city).State=EntityState.Modified;
            return city;
        }
    }
}
