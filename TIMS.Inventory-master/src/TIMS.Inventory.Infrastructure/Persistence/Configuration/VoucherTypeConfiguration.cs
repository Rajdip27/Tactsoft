using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMS.Inventory.Infrastructure.Models;

namespace TIMS.Inventory.Infrastructure.Persistence.Configuration;

public class VoucherTypeConfiguration : IEntityTypeConfiguration<VoucherType>
{
    public void Configure(EntityTypeBuilder<VoucherType> entity)
    {
        entity.ToTable("VoucherType");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.VoucherTypeId);
        entity.HasIndex(e => e.VoucherTypeId).IsUnique();
        entity.Property(e => e.Abbr)
            .HasMaxLength(10)
            .IsUnicode(false)
            .HasColumnName("abbr");
        entity.Property(e => e.Description)
            .HasMaxLength(150)
            .IsUnicode(false);

    }
}
