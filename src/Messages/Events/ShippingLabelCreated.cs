using NServiceBus;

namespace Messages
{
    public record ShippingLabelCreated(string OrderId) : IEvent;
}