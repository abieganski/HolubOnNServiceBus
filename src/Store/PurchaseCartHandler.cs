using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Store
{    
    public class PaymentAcceptedHandler : IHandleMessages<PaymentAccepted>
    {
        static readonly ILog log = LogManager.GetLogger<PaymentAcceptedHandler>();
        static readonly Random random = new Random();

        public Task Handle(PaymentAccepted message, IMessageHandlerContext context)
        {
            log.Info($"Received {message.GetType()}, OrderId = {message.OrderId}");

            
            
            var sendReceiptToCustomer = new SendReceiptToCustomer(message.OrderId);
       
            log.Info($"Publishing {sendReceiptToCustomer.GetType()}, OrderId = {message.OrderId}");
            return context.Publish(sendReceiptToCustomer);
        }
    }
}
