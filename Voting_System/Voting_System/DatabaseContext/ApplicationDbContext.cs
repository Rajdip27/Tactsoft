using Microsoft.EntityFrameworkCore;
using Voting_System.Models;
using VotingSystem.Models;

namespace VotingSystem.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AspInfoDepartment> AspInfoDepartments { get; set; }
        public DbSet<CreateUser> CreateUsers { get;set; }
        public DbSet<AspInfoCategory> AspInfoCategories { get; set; }
        public DbSet<AspInfoOption> AspInfoOption { get; set; }
        public DbSet<CreateAdmin> CreateAdmins { get; set; }
    }
}
