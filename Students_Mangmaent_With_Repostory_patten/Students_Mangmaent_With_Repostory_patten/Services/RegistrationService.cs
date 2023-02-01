using Microsoft.EntityFrameworkCore;
using Students_Mangmaent_With_Repostory_patten.DatabaseContext;
using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public class RegistrationService : IRegistration
    {
        private readonly ApplicationDbContext _dbContext;
        public RegistrationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<Registrion> Create(Registrion registrion)
        {
            await _dbContext.AddAsync(registrion);
            return registrion;
        }

        public async Task Delete(int id)
        {
            var Result = await _dbContext.Registrions.FindAsync(id);
            _dbContext.Entry(Result).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Registrion>> GetAllSt()
        {
            return await _dbContext.Registrions.ToListAsync();
        }

        public async Task<Registrion> GetById(int id)
        {
            var Result = await _dbContext.Registrions.FindAsync(id);
            return Result;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Registrion registrion)
        {
            _dbContext.Entry(registrion).State = EntityState.Modified;
        }
    }
}
