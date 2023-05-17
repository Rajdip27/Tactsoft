using Microsoft.EntityFrameworkCore;
using Test_Master_Deitals.Models;

namespace Test_Master_Deitals.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Experience> Experience { get; set; }
    }
}
