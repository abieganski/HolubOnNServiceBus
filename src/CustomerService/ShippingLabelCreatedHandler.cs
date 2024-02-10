using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace CustomerService
{

    public class ShippingLabelCreatedHandler : IHandleMessages<ShippingLabelCreated>
    {
        static readonly ILog log = LogManager.GetLogger<ShippingLabelCreatedHandler>();

        public async Task Handle(ShippingLabelCreated message, IMessageHandlerContext context)
        {
            log.Info($"CustomerService has received {message.GetType()}, OrderId = {message.OrderId}");
            
            var addShippingInfoToCustomerAccount = new AddShippingInfoToCustomerAccount(message.OrderId);
            
            log.Info($"CustomerService publish {addShippingInfoToCustomerAccount.GetType()}, OrderId = {addShippingInfoToCustomerAccount.OrderId}");
            await context.Publish(addShippingInfoToCustomerAccount);
        }
    }
}