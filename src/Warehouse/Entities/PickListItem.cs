using Shared;

namespace Warehouse.Entities;

public class PickListItem : Entity
{
    public int PickListItemId { get; set; }
    public string Sku { get; set; }
    public int Quantity { get; set; }
}