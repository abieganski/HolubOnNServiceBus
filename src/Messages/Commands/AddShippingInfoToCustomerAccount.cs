using NServiceBus;

namespace Messages
{
    public record AddShippingInfoToCustomerAccount(string OrderId) : ICommand;
}