using Microsoft.EntityFrameworkCore;
using MVC_CURD.Models;

namespace MVC_CURD.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options):base(Options)
        {

        }
       public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
