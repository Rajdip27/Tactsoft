using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Infrastructure.EntityConfiguration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.State).WithMany(m => m.Cities).HasForeignKey(x => x.StateId);
        builder.HasData(new City
        {
            Id = 1,
            StateId = 1,
            Name = "Mohammadpur",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new City
        {
            Id = 2,
            StateId = 1,
            Name = "Dhanmondi",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new City
        {
            Id = 3,
            StateId = 2,
            Name = "Nator",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new City
        {
            Id = 4,
            StateId = 2,
            Name = "Sirajganj",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new City
        {
            Id = 5,
            StateId = 3,
            Name = "New York City",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new City
        {
            Id = 6,
            StateId = 3,
            Name = "Buffalo",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new City
        {
            Id = 7,
            StateId = 4,
            Name = "Huntsville",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new City
        {
            Id = 8,
            StateId = 4,
            Name = "Montgomery",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        });
    }
}
