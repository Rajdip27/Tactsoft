using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Application.Models.Entities;

public class EmployeeVM : IEntityVM
{
    public long Id { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(50)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public Boolean Ssc { get; set; }
    public Boolean Hsc { get; set; }
    public Boolean Bsc { get; set; }
    public Boolean Msc { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string Picture { get; set; }
    public IFormFile PictureFile { get; set; }

    public long CountryId { get; set; }
    public long StateId { get; set; }
    public long CityId { get; set; }


    public CountryVM Country { get; set; }
    public StateVM State { get; set; }
    public CityVM City { get; set; }

}
