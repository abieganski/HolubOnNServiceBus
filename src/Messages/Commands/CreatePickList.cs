using System.Collections.Generic;
using NServiceBus;

namespace Messages
{
    public record CreatePickList(string OrderId, List<string> skus) : ICommand;
}