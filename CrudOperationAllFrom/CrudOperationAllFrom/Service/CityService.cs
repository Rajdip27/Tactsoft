using CrudOperation.Models;
using CrudOperationAllFrom.Database;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationAllFrom.Service
{
    public class CityService : ICity
    {
        private readonly ApplicationDbContext _dbContext;
        public CityService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<City> Create(City city)
        {
           await _dbContext.AddAsync(city);
            return city;
        }

        public async Task Delete(int id)
        {
           var Result = await _dbContext.Cities.FindAsync(id);
            _dbContext.Entry(Result).State=EntityState.Deleted;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _dbContext.Cities.ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _dbContext.Cities.FindAsync(id);
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task<City> Update(City city)
        {
           _dbContext.Entry(city).State=EntityState.Modified;
            return city;
        }
    }
}
