namespace Dedsi.Ddd.Domain.Entities;

public interface IEntity
{
    
}

public interface IEntity<out TKey> : IEntity
{
    TKey Id { get; }
}