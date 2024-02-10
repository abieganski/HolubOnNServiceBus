using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace OrderProcessing
{
    public class CartPurchasedHandler : IHandleMessages<CartPurchased>
    {
        static readonly ILog log = LogManager.GetLogger<CartPurchasedHandler>();

        public async Task Handle(CartPurchased message, IMessageHandlerContext context)
        {
            log.Info($"OrderProcessing has received {message.GetType()}, OrderId = {message.OrderId}");


            var issueAnInvoice = new IssueAnInvoice(message.OrderId);
        
            log.Info($"OrderProcessing publish {issueAnInvoice.GetType()}, OrderId = {issueAnInvoice.OrderId}");
            await context.Publish(issueAnInvoice);
        }
    }
}