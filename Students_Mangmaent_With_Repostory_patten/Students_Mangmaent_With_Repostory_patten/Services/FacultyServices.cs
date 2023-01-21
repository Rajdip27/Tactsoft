using Microsoft.EntityFrameworkCore;
using Students_Mangmaent_With_Repostory_patten.DatabaseContext;
using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public class FacultyServices : IFaculty
    {
      private readonly  ApplicationDbContext _DbContext;
        public FacultyServices(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Faculty> Create(Faculty faculty)
        {
            await _DbContext.AddAsync(faculty);
            return faculty;
        }

        public async Task Delete(int id)
        {
            var result = await _DbContext.Facultys.FindAsync(id);
            _DbContext.Facultys.Remove(result);
        }

        public async Task<IEnumerable<Faculty>> GetAllF()
        {
            return await _DbContext.Facultys.ToListAsync();
        }

        public async Task<Faculty> GetById(int id)
        {
            var Result = await _DbContext.Facultys.FindAsync(id);
            return Result;
        }

        public async Task Save()
        {
            await _DbContext.SaveChangesAsync();
        }

        public async Task<Faculty> Update(Faculty faculty)
        {
             _DbContext.Entry(faculty).State = EntityState.Modified;
            return faculty;
        }
    }
}
