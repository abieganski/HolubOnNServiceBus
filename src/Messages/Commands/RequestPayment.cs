using NServiceBus;

namespace Messages
{
    public record RequestPayment(string OrderId) : ICommand;
}