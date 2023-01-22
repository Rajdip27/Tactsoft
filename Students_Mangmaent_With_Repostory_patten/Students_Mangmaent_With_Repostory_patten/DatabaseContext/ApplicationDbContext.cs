using Microsoft.EntityFrameworkCore;
using Students_Mangmaent_With_Repostory_patten.Models;

namespace Students_Mangmaent_With_Repostory_patten.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
