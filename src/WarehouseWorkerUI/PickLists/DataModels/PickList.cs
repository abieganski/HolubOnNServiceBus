using System;

namespace WarehouseWorkerUI.PickLists.DataModels;

public class PickList
{
    public int PickListId { get; init; }  
    
    public bool IsPicked { get; init; }
    public DateTime WhenCreated { get; init; }
    
    public int TotalQuantity { get; init; }

}