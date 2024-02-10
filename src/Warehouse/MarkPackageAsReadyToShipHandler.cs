using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Warehouse
{

    public class MarkPackageAsReadyToShipHandler : IHandleMessages<MarkPackageAsReadyToShip>
    {
        static readonly ILog log = LogManager.GetLogger<MarkPackageAsReadyToShipHandler>();

        public async Task Handle(MarkPackageAsReadyToShip message, IMessageHandlerContext context)
        {
            log.Info($"Warehouse has received {message.GetType()}, OrderId = {message.OrderId}");
            
            
            // todo: mark package as ready to ship in the db
            
            
            
            var packageReadyToShip = new PackageReadyToShip(message.OrderId);
            
            log.Info($"Publishing {packageReadyToShip.GetType()}, OrderId = {message.OrderId}");
            await context.Publish(packageReadyToShip);
        }
    }
}