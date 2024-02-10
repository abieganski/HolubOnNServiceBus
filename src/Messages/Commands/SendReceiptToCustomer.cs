using NServiceBus;

namespace Messages
{
    public record SendReceiptToCustomer(string OrderId) : ICommand;
}