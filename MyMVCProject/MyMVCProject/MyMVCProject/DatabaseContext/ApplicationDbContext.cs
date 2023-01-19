using Microsoft.EntityFrameworkCore;
using MyMVCProject.Models;

namespace MyMVCProject.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext > options):base(options)
        {

        }
        public DbSet<Registration> Registrations { get; set; }
    }
}
