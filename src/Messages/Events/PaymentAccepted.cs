using NServiceBus;

namespace Messages
{
    public record PaymentAccepted(string OrderId) : IEvent;
}