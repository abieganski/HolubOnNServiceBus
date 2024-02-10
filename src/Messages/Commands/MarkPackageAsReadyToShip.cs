using NServiceBus;

namespace Messages
{
    public record MarkPackageAsReadyToShip(string OrderId) : ICommand;
}