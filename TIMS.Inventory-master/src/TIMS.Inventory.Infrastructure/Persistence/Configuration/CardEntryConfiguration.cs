using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMS.Inventory.SharedKernel.Entities;

namespace TIMS.Inventory.Infrastructure.Persistence.Configuration;

public class CardEntryConfiguration : IEntityTypeConfiguration<CardEntry>
{
    public void Configure(EntityTypeBuilder<CardEntry> entity)
    {
        entity.ToTable("CardEntry");
        entity.HasKey(e => e.Id).HasName("PK_CardEntry_1");

        entity.HasIndex(e => e.CardId).IsUnique();

        entity.Property(e => e.CardId).HasColumnName("CardID");
        entity.Property(e => e.CardName)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("Card_Name");
        entity.Property(e => e.SlNo).HasColumnName("SLNO");
    }
}
