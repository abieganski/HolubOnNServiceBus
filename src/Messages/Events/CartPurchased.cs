using NServiceBus;

namespace Messages
{
    public record CartPurchased(string OrderId) : IEvent;
}