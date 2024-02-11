using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseWorkerUI.PickLists.DataModels;

namespace WarehouseWorkerUI.PickLists;

public interface IProvidePickLists
{
    Task<List<PickList>> GetPickLists();
}