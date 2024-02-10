using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Context;
using Warehouse.Entities;

namespace Warehouse;

public class PickListRepository : IPickListRepository
{
    private readonly IWarehouseDbContext _warehouseDbContext;

    public PickListRepository(IWarehouseDbContext warehouseDbContext)
    {
        _warehouseDbContext = warehouseDbContext;
    }

    public async Task AddNew(PickList pickList)
    {
        await _warehouseDbContext.PickLists.AddAsync(pickList);
    }

    public async Task MarkPackageAsReadyToShip(int pickListId)
    {
        var pickList = await _warehouseDbContext.PickLists.FindAsync(pickListId);
        pickList.MarkPicked();
    }

    public async Task<List<PickList>> GetAllNotPicked()
    {
        return await _warehouseDbContext.PickLists
            .Include(x => x.Items)
            .Where(x => !x.IsPicked)
            .ToListAsync();
    }
    
    public async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        await _warehouseDbContext.SaveChangesAsync(cancellationToken);
    }
}