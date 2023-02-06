using MvcShortProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcShortProject.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)   
        {

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Deperment> Deperments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
