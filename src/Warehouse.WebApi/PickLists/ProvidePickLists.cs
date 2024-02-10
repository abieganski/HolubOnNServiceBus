using Dapper;
using Warehouse.WebApi.DbConnection;
using Warehouse.WebApi.PickLists.DataModels;

namespace Warehouse.WebApi;

public class ProvidePickLists(ISqlConnectionFactory sqlConnectionFactory) : IProvidePickLists
{
    public async Task<List<PickList>> GetPickList()
    {
        const string query = @"SELECT pl.PickListId, IsPicked, pl.WhenCreated, sum(pli.Quantity) as [TotalQuantity]
  FROM PickLists pl
  JOIN PickListItems pli on pl.PickListId = pli.PickListId

GROUP BY pl.PickListId, IsPicked, pl.WhenCreated
  
  ORDER BY pl.WhenCreated DESC";

        await using var connection = sqlConnectionFactory.GetOpenConnection();
        
        var pickLists = (await connection.QueryAsync<PickList>(query)).ToList();

        return pickLists;
    }
}