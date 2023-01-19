using Microsoft.EntityFrameworkCore;
using Student_Management.Models;

namespace Student_Management.DatabaseContext
{
    public class StudentManagementDbContext:DbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options):base(options)
        {

        }
        public DbSet<Cource> Cources { get;set;}
        public DbSet<Student> Students { get;set;}
        public DbSet<Faculty> Facultys { get;set;}
    }
}
