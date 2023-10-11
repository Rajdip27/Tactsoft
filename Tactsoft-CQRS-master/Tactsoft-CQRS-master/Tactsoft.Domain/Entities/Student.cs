using Tactsoft.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Domain.Entities;

public class Student : BaseEntity, IEntity
{
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
