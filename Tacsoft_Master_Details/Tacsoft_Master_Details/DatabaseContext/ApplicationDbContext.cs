using Microsoft.EntityFrameworkCore;
using Tacsoft_Master_Details.Models;

namespace Tacsoft_Master_Details.DatabaseContext
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set;}
        public DbSet<PurchaseItem> PurchasesItem { get; set; }
    }
}
