using Microsoft.AspNetCore.Identity;

namespace StudentManagement.Models;

public class AppUser: IdentityUser
{
    public string Name { get; set; }
    public string Address { get; set; }

    public long CreatedBy { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }
}