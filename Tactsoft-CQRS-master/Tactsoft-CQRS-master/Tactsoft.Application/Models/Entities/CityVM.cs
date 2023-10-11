using Newtonsoft.Json;
using Tactsoft.Application.Models;
using Tactsoft.Application.Models.Entities;
using Tactsoft.Domain.Base;

namespace Tactsoft.Application.Models.Entities;

public class CityVM : IEntityVM
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long StateId { get; set; }

    [JsonIgnore]
    public StateVM State { get; set; }

    [JsonIgnore]
    public ICollection<EmployeeVM> Employees { get; set; } = new HashSet<EmployeeVM>();
}
