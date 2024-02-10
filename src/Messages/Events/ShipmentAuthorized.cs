using NServiceBus;

namespace Messages
{
    public record ShipmentAuthorized(string OrderId) : IEvent;
}