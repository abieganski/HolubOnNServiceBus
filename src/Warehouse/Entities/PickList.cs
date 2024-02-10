using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Warehouse.Entities;

public class PickList : AggregateBase
{
    public int PickListId { get; init; }  // we could use OrderId here, but we're in a different bounded context, so we'll use a different id  
    
    public string OrderId { get; init; }
    public bool IsPicked { get; private set; }
    public DateTime? WhenPicked { get; private set; }

    public List<PickListItem> Items { get; init; } = new List<PickListItem>();
    
    public void MarkPicked()
    {
        IsPicked = true;
        WhenPicked = DateTime.UtcNow;
        MarkModified();
    }

    public static PickList Create(string orderId, List<string> skus)
    {
        var pickList = new PickList
        {
            OrderId = orderId,
            Items = skus.Select(sku => new PickListItem { Sku = sku }).ToList()
        };
        return pickList;
    }
}