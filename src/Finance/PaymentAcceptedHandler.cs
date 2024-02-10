using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Finance
{

    public class PaymentAcceptedHandler : IHandleMessages<PaymentAccepted>
    {
        static readonly ILog log = LogManager.GetLogger<PaymentAcceptedHandler>();

        public async Task Handle(PaymentAccepted message, IMessageHandlerContext context)
        {
            log.Info($"Finance has received {message.GetType()}, OrderId = {message.OrderId}");


            var authorizeShipment = new AuthorizeShipment(message.OrderId);
            
            log.Info($"Finance publish {authorizeShipment.GetType()}, OrderId = {authorizeShipment.OrderId}");
            await context.Publish(authorizeShipment);
        }
    }
}