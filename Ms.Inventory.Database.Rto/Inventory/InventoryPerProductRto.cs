using System.Collections.Generic;

namespace Ms.Inventory.Database.Rto.Inventory
{
    public class InventoryPerProductRto
    {
        public string ProductName { get; set; }
        public IEnumerable<InventoryDataRto> Items { get; set; }
    }
}