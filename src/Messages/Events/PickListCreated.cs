using NServiceBus;

namespace Messages
{
    public record PickListCreated(string OrderId) : IEvent;
}