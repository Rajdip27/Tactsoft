using Microsoft.EntityFrameworkCore;
using Resume_Manager.Models;

namespace Resume_Manager.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Applicant>  Applicants { get; set; }
    }
}
