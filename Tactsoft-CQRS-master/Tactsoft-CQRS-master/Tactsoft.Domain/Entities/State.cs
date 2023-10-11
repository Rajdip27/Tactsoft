using Tactsoft.Domain.Base;

namespace Tactsoft.Domain.Entities;

public class State : BaseEntity, IEntity
{
    public string Name { get; set; }

    public long CountryId { get; set; }

    public Country Country { get; set; }

    public ICollection<City> Cities { get; set; } = new HashSet<City>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
