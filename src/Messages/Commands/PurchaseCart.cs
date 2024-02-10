using NServiceBus;

namespace Messages
{
    public record PurchaseCart(string OrderId) : ICommand;
}