using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMS.Inventory.SharedKernel.Entities;

namespace TIMS.Inventory.Infrastructure.Persistence.Configuration;
public class YearInfoConfiguration : IEntityTypeConfiguration<YearInfo>
{
    public void Configure(EntityTypeBuilder<YearInfo> entity)
    {
        entity.ToTable("YearInfo");
        entity.HasKey(e => e.Id);
        entity.HasIndex(e => e.YearId).IsUnique();

        entity.Property(e => e.Description)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.EndDate).HasColumnType("datetime2");
        entity.Property(e => e.OpeningField)
            .HasMaxLength(20)
            .IsUnicode(false);
        entity.Property(e => e.StartDate).HasColumnType("datetime2");
    }
}
