using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse;

public interface IPickListRepository
{
    public Task AddNew(PickList pickList);

    public Task MarkPackageAsReadyToShip(int pickListId);

    public Task<List<PickList>> GetAllNotPicked();
    Task SaveChanges(CancellationToken cancellationToken = default);
}