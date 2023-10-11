using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Application.Models.Entities;

public class StudentVM : IEntityVM
{
    public long Id { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }

    public string Address { get; set; }
}
