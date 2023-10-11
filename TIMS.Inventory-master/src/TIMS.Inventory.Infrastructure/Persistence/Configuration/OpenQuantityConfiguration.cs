using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMS.Inventory.SharedKernel.Entities;

namespace TIMS.Inventory.Infrastructure.Persistence.Configuration;

public class OpenQuantityConfiguration : IEntityTypeConfiguration<OpenQuantity>
{
    public void Configure(EntityTypeBuilder<OpenQuantity> entity)
    {
        entity.ToTable("OpenQuantity");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.SlNo);
        entity.HasIndex(e => e.SlNo).IsUnique();

        entity.Property(e => e.CompanyId);
        entity.Property(e => e.CompanyYearId);
        entity.Property(e => e.ItemId);
        entity.Property(e => e.OpenQuantity1);
        entity.Property(e => e.PurchaseRate);
        entity.Property(e => e.ReorderQuantity);
        entity.Property(e => e.SaleRate);
    }
}
