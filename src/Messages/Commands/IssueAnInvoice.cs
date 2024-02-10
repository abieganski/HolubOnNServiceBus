using NServiceBus;

namespace Messages
{
    public record IssueAnInvoice(string OrderId) : ICommand;
}