namespace Tactsoft.Domain.Base;

public interface IEntity<T> where T : IEquatable<T>
{
    T Id { get; set; }

    long CreatedBy { get; set; }
    DateTimeOffset CreatedDate { get; set; }
    long? UpdatedBy { get; set; }
    DateTimeOffset? UpdatedDate { get; set; }
    bool IsDelete { get; set; }

}

public interface IEntity : IEntity<long>
{

}