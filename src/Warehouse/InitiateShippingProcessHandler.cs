using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Warehouse
{

    public class InitiateShippingProcessHandler : IHandleMessages<InitiateShippingProcess>
    {
        static readonly ILog log = LogManager.GetLogger<ShipmentAuthorizedHandler>();

        public Task Handle(InitiateShippingProcess message, IMessageHandlerContext context)
        {
            log.Info($"Warehouse has received {message.GetType()}, OrderId = {message.OrderId}");
            
            
            // create label
            
            
            return Task.CompletedTask;
        }
    }
}