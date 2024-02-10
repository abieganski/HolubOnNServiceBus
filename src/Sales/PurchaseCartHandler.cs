using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Sales
{    
    public class PurchaseCartHandler : IHandleMessages<PurchaseCart>
    {
        static readonly ILog log = LogManager.GetLogger<PurchaseCartHandler>();
        static readonly Random random = new Random();

        public Task Handle(PurchaseCart message, IMessageHandlerContext context)
        {
            log.Info($"Received {message.GetType()}, OrderId = {message.OrderId}");

            // This is normally where some business logic would occur

            #region ThrowTransientException
            // Uncomment to test throwing transient exceptions
            //if (random.Next(0, 5) == 0)
            //{
            //    throw new Exception("Oops");
            //}
            #endregion

            #region ThrowFatalException
            // Uncomment to test throwing fatal exceptions
            //throw new Exception("BOOM");
            #endregion

            
            var cartPurchased = new CartPurchased(message.OrderId);
       
            log.Info($"Publishing {cartPurchased.GetType()}, OrderId = {message.OrderId}");
            return context.Publish(cartPurchased);
        }
    }
}
