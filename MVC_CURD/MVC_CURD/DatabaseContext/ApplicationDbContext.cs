using Microsoft.EntityFrameworkCore;
using MVC_CURD.Models;

namespace MVC_CURD.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
