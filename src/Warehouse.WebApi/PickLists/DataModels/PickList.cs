namespace Warehouse.WebApi.PickLists.DataModels;

public class PickList
{
    public int PickListId { get; init; } 
    
    public bool IsPicked { get; private set; }
    public DateTime? WhenCreated { get; private set; }
    
    public int TotalQuantity { get; private set; }

}