using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Finance
{

    public class AuthorizeShipmentHandler : IHandleMessages<AuthorizeShipment>
    {
        static readonly ILog log = LogManager.GetLogger<AuthorizeShipmentHandler>();

        public async Task Handle(AuthorizeShipment message, IMessageHandlerContext context)
        {
            log.Info($"Finance has received {message.GetType()}, OrderId = {message.OrderId}");

            
            var shipmentAuthorized = new ShipmentAuthorized(message.OrderId);
            
            log.Info($"Finance publish {shipmentAuthorized.GetType()}, OrderId = {shipmentAuthorized.OrderId}");
            await context.Publish(shipmentAuthorized);
        }
    }
}