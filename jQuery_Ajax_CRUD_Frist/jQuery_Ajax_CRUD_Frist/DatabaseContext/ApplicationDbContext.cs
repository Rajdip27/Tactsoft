using jQuery_Ajax_CRUD_Frist.Models;
using Microsoft.EntityFrameworkCore;

namespace jQuery_Ajax_CRUD_Frist.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
