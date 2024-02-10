using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Finance
{

    public class RequestPaymentHandler : IHandleMessages<RequestPayment>
    {
        static readonly ILog log = LogManager.GetLogger<RequestPaymentHandler>();

        public async Task Handle(RequestPayment message, IMessageHandlerContext context)
        {
            log.Info($"Finance has received {message.GetType()}, OrderId = {message.OrderId}");

            
            // todo: send a payment request to the payment gateway
            await Task.Delay(6000);
            
            var paymentAccepted = new PaymentAccepted(message.OrderId);
            
            log.Info($"Finance publish {paymentAccepted.GetType()}, OrderId = {paymentAccepted.OrderId}");
            await context.Publish(paymentAccepted);
        }
    }
}