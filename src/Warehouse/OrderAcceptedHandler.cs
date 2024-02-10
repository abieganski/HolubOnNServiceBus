using System.Collections.Generic;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Warehouse
{

    public class OrderAcceptedHandler : IHandleMessages<OrderAccepted>
    {
        static readonly ILog log = LogManager.GetLogger<OrderAcceptedHandler>();

        public async Task Handle(OrderAccepted message, IMessageHandlerContext context)
        {
            log.Info($"Warehouse has received {message.GetType()}, OrderId = {message.OrderId}");
            
            var initiateShippingProcess = new InitiateShippingProcess(message.OrderId);
            
            log.Info($"Publishing {initiateShippingProcess.GetType()}, OrderId = {message.OrderId}");
            await context.Publish(initiateShippingProcess);


            var createPickList = new CreatePickList(message.OrderId, message.Skus);
            
            log.Info($"Publishing {createPickList.GetType()}, OrderId = {message.OrderId}");
            await context.Publish(createPickList);
        }
    }
}