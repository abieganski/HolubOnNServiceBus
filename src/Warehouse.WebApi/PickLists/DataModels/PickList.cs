namespace Warehouse.WebApi.PickLists.DataModels;

public class PickList
{
    public int PickListId { get; init; }  // we could use OrderId here, but we're in a different bounded context, so we'll use a different id  
    
    public bool IsPicked { get; private set; }
    public DateTime? WhenPicked { get; private set; }
    
    public int TotalQuantity { get; private set; }

}