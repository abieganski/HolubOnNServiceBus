using NServiceBus;

namespace Messages
{
    public record InitiateShippingProcess(string OrderId) : ICommand;
}