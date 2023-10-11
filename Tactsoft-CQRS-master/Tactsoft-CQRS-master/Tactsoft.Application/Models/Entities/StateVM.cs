using Newtonsoft.Json;
using Tactsoft.Application.Models;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Domain.Base;

namespace Tactsoft.Application.Models.Entities;

public class StateVM : IEntityVM
{
    public long Id { get; set; }

    public string Name { get; set; }
    public long CountryId { get; set; }

    [JsonIgnore]
    public CountryVM Country { get; set; }

    [JsonIgnore]
    public ICollection<CityVM> Cities { get; set; } = new HashSet<CityVM>();
    [JsonIgnore]
    public ICollection<EmployeeVM> Employees { get; set; } = new HashSet<EmployeeVM>();
}
