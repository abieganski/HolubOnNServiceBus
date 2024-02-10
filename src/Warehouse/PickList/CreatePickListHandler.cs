using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;
using Warehouse.Entities;

namespace Warehouse
{

    public class CreatePickListHandler : IHandleMessages<CreatePickList>
    {
        static readonly ILog log = LogManager.GetLogger<ShipmentAuthorizedHandler>();

        private readonly IPickListRepository _pickListRepository;

        public CreatePickListHandler(IPickListRepository pickListRepository)
        {
            _pickListRepository = pickListRepository;
        }

        public async Task Handle(CreatePickList message, IMessageHandlerContext context)
        {
            log.Info($"Warehouse has received {message.GetType()}, OrderId = {message.OrderId}");
            
            // create pick list
            var pickList = PickList.Create(message.OrderId, message.skus);
            await _pickListRepository.AddNew(pickList);
            await _pickListRepository.SaveChanges(context.CancellationToken);
            
            var pickListCreated = new PickListCreated(message.OrderId);
            log.Info($"Warehouse publish {pickListCreated.GetType()}, OrderId = {pickListCreated.OrderId}");
            await context.Publish(pickListCreated);            
        }
    }
}