using Newtonsoft.Json;

namespace Tactsoft.Application.Models.Entities;

public class CountryVM : IEntityVM
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Flag { get; set; }

    [JsonIgnore]
    public ICollection<CountryVM> Countries { get; set; } = new HashSet<CountryVM>();
    [JsonIgnore]
    public ICollection<EmployeeVM> Employees { get; set; } = new HashSet<EmployeeVM>();

}
