using First_Jqery_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace First_Jqery_Project.DatabaseContext
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
