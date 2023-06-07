using Microsoft.EntityFrameworkCore;
using New_Pratice_Project.Models;

namespace New_Pratice_Project.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Deperment> Deperments { get; set; }
    }
}
