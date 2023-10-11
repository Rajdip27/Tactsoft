using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Infrastructure.EntityConfiguration;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Country).WithMany(x => x.Employees).HasForeignKey(x => x.CountryId);
        builder.HasOne(x => x.State).WithMany(x => x.Employees).HasForeignKey(x => x.StateId);
        builder.HasOne(x => x.City).WithMany(x => x.Employees).HasForeignKey(x => x.CityId);
        builder.HasData(new Employee
        {
            Id = 1,
            FirstName = "Shahadat",
            LastName = "Hassain",
            Email = "sahadat@gmail.com",
            Phone = "017xxxxxxxxx",
            Address = "12/2, Dhanmondi, Dhaka",
            DateOfBirth = new DateTime(1996, 01, 01),
            Gender = "Male",
            Ssc = true,
            Hsc = true,
            Bsc = true,
            Msc = false,
            ZipCode = "1234",
            Picture = "",
            CountryId = 1,
            StateId = 1,
            CityId = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDelete = false,
        }, new Employee
        {
            Id = 2,
            FirstName = "Mamun",
            LastName = "Rahman",
            Email = "mamun@gmail.com",
            Phone = "017xxxxxxxxx",
            Address = "12/2, Dhanmondi, Dhaka",
            DateOfBirth = new DateTime(1999, 08, 03),
            Gender = "Male",
            Ssc = true,
            Hsc = true,
            Bsc = true,
            Msc = false,
            ZipCode = "1234",
            Picture = "",
            CountryId = 1,
            StateId = 1,
            CityId = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDelete = false,
        }, new Employee
        {
            Id = 3,
            FirstName = "Rahat",
            LastName = "Hasan",
            Email = "rahat@gmail.com",
            Phone = "017xxxxxxxxx",
            Address = "12/2, Dhanmondi, Dhaka",
            DateOfBirth = new DateTime(1993, 04, 30),
            Gender = "Male",
            Ssc = true,
            Hsc = true,
            Bsc = true,
            Msc = false,
            ZipCode = "1234",
            Picture = "",
            CountryId = 1,
            StateId = 1,
            CityId = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDelete = false,
        }, new Employee
        {
            Id = 4,
            FirstName = "Fara",
            LastName = "Khan",
            Email = "fara@gmail.com",
            Phone = "017xxxxxxxxx",
            Address = "12/2, Dhanmondi, Dhaka",
            DateOfBirth = new DateTime(1996, 08, 05),
            Gender = "Female",
            Ssc = true,
            Hsc = true,
            Bsc = true,
            Msc = false,
            ZipCode = "1234",
            Picture = "",
            CountryId = 1,
            StateId = 1,
            CityId = 1,
            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDelete = false,
        });
    }
}
