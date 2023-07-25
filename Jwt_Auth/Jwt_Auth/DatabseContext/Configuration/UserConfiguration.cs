using Jwt_Auth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jwt_Auth.DatabseContext.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("users");
		builder.HasKey(x => x.UserName);
		builder.HasIndex(x => x.UserName).IsUnique();
	}
}
