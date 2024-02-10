using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Warehouse
{

    public class PackageReadyToShipHandler : IHandleMessages<PackageReadyToShip>
    {
        static readonly ILog log = LogManager.GetLogger<PackageReadyToShipHandler>();

        public async Task Handle(PackageReadyToShip message, IMessageHandlerContext context)
        {
            log.Info($"Warehouse has received {message.GetType()}, OrderId = {message.OrderId}");
            
            var shipPackage = new ShipPackage(message.OrderId);
            
            log.Info($"Publishing {shipPackage.GetType()}, OrderId = {message.OrderId}");
            await context.Publish(shipPackage);
        }
    }
}