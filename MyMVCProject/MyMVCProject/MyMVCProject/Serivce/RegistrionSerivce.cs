using Microsoft.EntityFrameworkCore;
using MyMVCProject.DatabaseContext;
using MyMVCProject.Models;

namespace MyMVCProject.Serivce
{
    public class RegistrionSerivce : IRegistrion
    {
      private readonly  ApplicationDbContext _dbContext;
        public RegistrionSerivce(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Registration> Create(Registration registration)
        {
           await _dbContext.AddAsync(registration);
            return registration;
        }

        public async Task DeleteById(int id)
        {
            var Result = await _dbContext.Registrations.FindAsync(id);
            _dbContext.Entry(Result).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Registration>> GetAll()
        {
             
            return await _dbContext.Registrations.ToListAsync();
        }

        public async Task<Registration> GetById(int id)
        {
            var Result=await _dbContext.Registrations.FindAsync(id);
            return Result;
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Registration registration)
        {
            _dbContext.Entry(registration).State = EntityState.Modified;
        }
    }
}
