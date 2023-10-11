using Tactsoft.Domain.Base;

namespace Tactsoft.Domain.Entities;

public class Country : BaseEntity, IEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Currency { get; set; }
    public string Flag { get; set; }

    public ICollection<State> States { get; set; } = new HashSet<State>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
