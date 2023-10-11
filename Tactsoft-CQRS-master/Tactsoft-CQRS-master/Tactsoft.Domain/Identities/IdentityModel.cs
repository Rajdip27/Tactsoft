using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Tactsoft.Domain.Identities;

public class IdentityModel
{
    [Table("Users")]
    public class User : IdentityUser<long>
    {


        public long CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

    }

    [Table("UserRoles")]
    public class UserRole : IdentityUserRole<long>
    {
    }

    [Table("UserClaims")]
    public class UserClaim : IdentityUserClaim<long>
    {

    }

    public class UserLogin : IdentityUserLogin<long>
    {
        [ForeignKey("User"), Key]
        public override long UserId { get => base.UserId; set => base.UserId = value; }
        public User Users { get; set; }
    }

    [NotMapped]
    public class RoleClaim : IdentityRoleClaim<long>
    {
    }

    [Table("UserTokens")]
    public class UserToken : IdentityUserToken<long>
    {
    }

    [Table("Roles")]
    public class Role : IdentityRole<long>
    {
        public Role() { }
        public Role(string name) { Name = name; }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public long CreatedBy { get; set; }
        public DateTimeOffset CreatedDateUtc { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDateUtc { get; set; }
    }
}

