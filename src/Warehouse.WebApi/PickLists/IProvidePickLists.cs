using Warehouse.WebApi.PickLists.DataModels;

namespace Warehouse.WebApi;

public interface IProvidePickLists
{
    Task<List<PickList>> GetPickList();
}