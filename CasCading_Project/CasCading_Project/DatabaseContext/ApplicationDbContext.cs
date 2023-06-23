using CasCading_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CasCading_Project.DatabaseContext
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StudentInfo> Students { get; set; }
    }
}
