namespace Shared;

public abstract class Entity
{
    public DateTime WhenCreated { get; set; } = DateTime.UtcNow;
    public DateTime? WhenUpdated { get; set; }

    protected void MarkModified()
    {
        WhenUpdated = DateTime.UtcNow;
    }
}