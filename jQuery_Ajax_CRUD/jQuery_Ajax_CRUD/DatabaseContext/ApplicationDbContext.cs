using jQuery_Ajax_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace jQuery_Ajax_CRUD.DatabaseContext
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
