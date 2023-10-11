using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMS.Inventory.SharedKernel.Entities;

namespace TIMS.Inventory.Infrastructure.Persistence.Configuration;
public class RuanItConfiguration : IEntityTypeConfiguration<RuanIt>
{
    public void Configure(EntityTypeBuilder<RuanIt> entity)
    {
        entity.ToTable("RuanIt");
        entity.HasKey(e => e.Id);
        entity.HasIndex(e => e.RuanItId).IsUnique();
        entity.Property(e => e.RuanItName)
            .HasMaxLength(30)
            .IsUnicode(false);
    }
}
