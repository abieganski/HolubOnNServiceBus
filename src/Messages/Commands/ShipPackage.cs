using NServiceBus;

namespace Messages
{
    public record ShipPackage(string OrderId) : ICommand;
}