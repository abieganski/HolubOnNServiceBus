using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Finance
{

    public class CartPurchasedHandler : IHandleMessages<CartPurchased>
    {
        static readonly ILog log = LogManager.GetLogger<CartPurchasedHandler>();

        public async Task Handle(CartPurchased message, IMessageHandlerContext context)
        {
            log.Info($"Finance has received {message.GetType()}, OrderId = {message.OrderId}");


            var requestPayment = new RequestPayment(message.OrderId);
            
            log.Info($"Finance publish {requestPayment.GetType()}, OrderId = {requestPayment.OrderId}");
            await context.Publish(requestPayment);
        }
    }
}