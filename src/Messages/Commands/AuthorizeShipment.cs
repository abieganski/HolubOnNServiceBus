using NServiceBus;

namespace Messages
{
    public record AuthorizeShipment(string OrderId) : ICommand;
}