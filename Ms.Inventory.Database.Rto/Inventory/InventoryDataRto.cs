using System;
using System.Collections.Generic;

namespace Ms.Inventory.Database.Rto.Inventory
{
    public class InventoryDataRto
    {
        public string InventoryId { get; set; }
        public long ItemReference { get; set; }
        public string Location { get; set; }
        public DateTimeOffset DateOfInventory { get; set; }
        public HashSet<string> Tags { get; set; }
    }
}