using Tactsoft.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Domain.Entities;

public class Employee : BaseEntity, IEntity
{
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public bool Ssc { get; set; }
    public bool Hsc { get; set; }
    public bool Bsc { get; set; }
    public bool Msc { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string Picture { get; set; }

    public long CountryId { get; set; }
    public long StateId { get; set; }
    public long CityId { get; set; }

    public Country Country { get; set; }
    public State State { get; set; }
    public City City { get; set; }

}
