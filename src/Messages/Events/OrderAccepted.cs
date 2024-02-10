using System.Collections.Generic;
using NServiceBus;

namespace Messages
{
    public record OrderAccepted(string OrderId, List<string> Skus) : IEvent;
}