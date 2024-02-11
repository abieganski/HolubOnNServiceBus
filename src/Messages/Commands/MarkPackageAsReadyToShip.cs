using NServiceBus;

namespace Messages
{
    public record MarkPackageAsReadyToShip(string PickListId) : ICommand;
}