using Microsoft.EntityFrameworkCore;
using Students_Mangmaent_With_Repostory_patten.DatabaseContext;
using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public class StudentServices : IStudent
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> Create(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            return student;
        }

        public async Task Delete(int id)
        {
           var st=await _dbContext.Students.FindAsync(id);
           _dbContext.Remove(st);
        }

        public async Task<IEnumerable<Student>> GetAllSt()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _dbContext.Students.FindAsync(id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
             _dbContext.Entry(student).State = EntityState.Modified;
        }
    }
}
