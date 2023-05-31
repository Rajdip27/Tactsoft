using Microsoft.EntityFrameworkCore;

namespace Test_Master_Details.DatabaseConteext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
    }
}
