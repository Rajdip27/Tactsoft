using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Tactsoft.Domain.Identities.IdentityModel;

namespace Tactsoft.Infrastructure.EntityConfiguration.AuthConfiguration;
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role
        {
            Id = 1,
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR",

        }, new Role
        {
            Id = 2,
            Name = "Employee",
            NormalizedName = "EMPLOYEE",
        }, new Role
        {
            Id = 3,
            Name = "Trainer",
            NormalizedName = "TRAINER"
        }, new Role
        {
            Id = 4,
            Name = "Student",
            NormalizedName = "STUDENT"
        });
    }
}
