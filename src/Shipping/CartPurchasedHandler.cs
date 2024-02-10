using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping
{

    public class CartPurchasedHandler : IHandleMessages<CartPurchased>
    {
        static readonly ILog log = LogManager.GetLogger<CartPurchasedHandler>();

        public Task Handle(CartPurchased message, IMessageHandlerContext context)
        {
            log.Info($"Shipping has received {message.GetType()}, OrderId = {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}