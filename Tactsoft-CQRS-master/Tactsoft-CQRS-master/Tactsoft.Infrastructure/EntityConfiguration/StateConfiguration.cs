using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Domain.Entities;

namespace Tactsoft.Infrastructure.EntityConfiguration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("States");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Country).WithMany(x => x.States).HasForeignKey(x => x.CountryId);
        builder.HasData(new State
        {
            Id = 1,
            CountryId = 1,
            Name = "Dhaka",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new State
        {
            Id = 2,
            CountryId = 1,
            Name = "Rajshahi",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new State
        {
            Id = 3,
            CountryId = 2,
            Name = "New York",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new State
        {
            Id = 4,
            CountryId = 2,
            Name = "Alabama",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        });
    }
}
