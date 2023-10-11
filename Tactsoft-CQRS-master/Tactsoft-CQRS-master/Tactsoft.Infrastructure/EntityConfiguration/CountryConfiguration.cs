using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Infrastructure.EntityConfiguration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");
        builder.HasKey(x => x.Id);
        builder.HasData(new Country
        {
            Id = 1,
            Name = "Bangladesh",
            Code = "BD",
            Currency = "BDT",
            Flag = "bd",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Country
        {
            Id = 2,
            Name = "United States",
            Code = "USA",
            Currency = "USD",
            Flag = "us",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Country
        {
            Id = 3,
            Name = "United Kingdom",
            Code = "UK",
            Currency = "GBP",
            Flag = "gb",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        });
    }
}
