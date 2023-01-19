using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;

namespace MyFirstApi.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Student> students { get; set; }
    }
}
