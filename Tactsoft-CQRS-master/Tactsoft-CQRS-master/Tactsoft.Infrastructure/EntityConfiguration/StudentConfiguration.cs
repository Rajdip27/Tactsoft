using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Infrastructure.EntityConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(x => x.Id);
        builder.HasData(new Student
        {
            Id = 1,
            FirstName = "Sumon",
            LastName = "Mia",
            Email = "sumon@gmail.com",
            Phone = "0171225588",
            Address = "12/2, Dhanmondi, Dhaka",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDelete = false,
        }, new Student
        {
            Id = 2,
            FirstName = "Rubel",
            LastName = "Hossain",
            Email = "rubel@gmail.com",
            Phone = "01929121212",
            Address = "22/2, Mohammadpur, Dhaka",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDelete = false,
        }, new Student
        {
            Id = 3,
            FirstName = "Raju",
            LastName = "Ahmed",
            Email = "raju@gmail.com",
            Phone = "0171225588",
            Address = "12/2, Dhanmondi, Dhaka",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDelete = false,
        }, new Student
        {
            Id = 4,
            FirstName = "Mithu",
            LastName = "Mia",
            Email = "mithu@gmail.com",
            Phone = "0171225588",
            Address = "12/2, Dhanmondi, Dhaka",
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDelete = false,
        });
    }
}
