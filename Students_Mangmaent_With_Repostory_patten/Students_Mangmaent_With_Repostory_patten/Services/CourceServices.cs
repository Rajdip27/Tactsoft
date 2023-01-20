using Microsoft.EntityFrameworkCore;
using Students_Mangmaent_With_Repostory_patten.DatabaseContext;
using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public class CourceServices : ICource
    {
      private readonly  ApplicationDbContext _DbContext;
        public CourceServices(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Cource> Create(Cource cource)
        {
            await _DbContext.AddAsync(cource);
            return cource;
        }

        public async Task Delete(int id)
        {
           var co=await _DbContext.Cources.FindAsync(id);
            _DbContext.Cources.Remove(co);
        }

        public async Task<IEnumerable<Cource>> GetAllCo()
        {
            var cource = await _DbContext.Cources.ToListAsync();
            return cource;
        }

        public async Task<Cource> GetById(int id)
        {
          var cource=await _DbContext.Cources.FindAsync(id);
            return cource;
        }

        public async Task Save()
        {
            await _DbContext.SaveChangesAsync();
        }

        public async Task<Cource> Update(Cource cource)
        {
            _DbContext.Entry(cource).State = EntityState.Modified;
            return cource;
        }
    }
}
