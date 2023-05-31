using Microsoft.EntityFrameworkCore;
using Personal_info.Models;

namespace Personal_info.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Progammer> Programs { get; set; }
    }
}
