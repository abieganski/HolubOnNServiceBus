using NServiceBus;

namespace Messages
{
    public record PackageReadyToShip(string OrderId) : IEvent;
}