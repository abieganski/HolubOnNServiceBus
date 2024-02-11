namespace Shared;

public abstract class AggregateBase : Entity
{
    public byte[] RowVersion { get; set; }
}