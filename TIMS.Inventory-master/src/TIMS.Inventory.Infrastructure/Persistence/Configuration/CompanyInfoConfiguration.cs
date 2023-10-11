using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMS.Inventory.SharedKernel.Entities;

namespace TIMS.Inventory.Infrastructure.Persistence.Configuration;

public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
{
    public void Configure(EntityTypeBuilder<CompanyInfo> entity)
    {
        entity.ToTable("CompanyInfo");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.BranchId);
        entity.HasIndex(e => e.BranchId).IsUnique(); 
        entity.Property(e => e.Address)
            .HasMaxLength(250)
            .IsUnicode(false);
        entity.Property(e => e.BranchName)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("BRName");
        entity.Property(e => e.CompanyName)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.ContactPerson)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Fax)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Phone)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Web)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
