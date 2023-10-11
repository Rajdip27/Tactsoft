using Tactsoft.Domain.Base;

namespace Tactsoft.Domain.Entities;

public class City : BaseEntity, IEntity
{
    public string Name { get; set; }

    public long StateId { get; set; }

    public State State { get; set; }

    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
