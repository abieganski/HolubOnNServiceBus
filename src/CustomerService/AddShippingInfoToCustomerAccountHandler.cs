using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace CustomerService
{

    public class AddShippingInfoToCustomerAccountHandler : IHandleMessages<AddShippingInfoToCustomerAccount>
    {
        static readonly ILog log = LogManager.GetLogger<AddShippingInfoToCustomerAccountHandler>();

        public async Task Handle(AddShippingInfoToCustomerAccount message, IMessageHandlerContext context)
        {
            log.Info($"CustomerService has received {message.GetType()}, OrderId = {message.OrderId}");
            
            // todo: implement logic to add shipping info to customer account
            
            
        }
    }
}