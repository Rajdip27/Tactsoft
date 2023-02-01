using Microsoft.EntityFrameworkCore;
using Students_Mangmaent_With_Repostory_patten.DatabaseContext;
using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.Services
{
    public class EmployeeServices : IEmployee
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> Create(Employee employee)
        {
            await _dbContext.AddAsync(employee);
            return employee;
        }

        public async Task Delete(int id)
        {
            var em = await _dbContext.Employees.FindAsync(id);
            _dbContext.Entry(em).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> Update(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            return employee;

        }
    }

}
