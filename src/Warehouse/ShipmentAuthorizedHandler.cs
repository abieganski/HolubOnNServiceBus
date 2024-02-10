using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Warehouse
{

    public class ShipmentAuthorizedHandler : IHandleMessages<ShipmentAuthorized>
    {
        static readonly ILog log = LogManager.GetLogger<ShipmentAuthorizedHandler>();

        public async Task Handle(ShipmentAuthorized message, IMessageHandlerContext context)
        {
            log.Info($"Warehouse has received {message.GetType()}, OrderId = {message.OrderId}");
            
            
            // todo: create shipping label and notify external shipping agent
            
           
            
            var shippingLabelCreated = new ShippingLabelCreated(message.OrderId);
            
            log.Info($"Publishing {shippingLabelCreated.GetType()}, OrderId = {message.OrderId}");
            await context.Publish(shippingLabelCreated);
        }
    }
}