using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TIMS.Inventory.SharedKernel.Entities;

namespace TIMS.Inventory.Infrastructure.Persistence.Configuration
{
    public class QuanItConfiguration : IEntityTypeConfiguration<QuanIt>
    {
        public void Configure(EntityTypeBuilder<QuanIt> entity)
        {
            entity.ToTable("QuanIt");
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.QuanItId).IsUnique();

            entity.Property(e => e.QuanItName)
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }

}