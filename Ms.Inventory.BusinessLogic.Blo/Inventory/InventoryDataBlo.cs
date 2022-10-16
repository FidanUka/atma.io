using System;
using System.Collections.Generic;

namespace Ms.Inventory.BusinessLogic.Blo.Inventory
{
    public class InventoryDataBlo
    {
        public string InventoryId { get; set; }
        public int ItemReference { get; set; }
        public string Location { get; set; }
        public DateTimeOffset DateOfInventory { get; set; }
        public HashSet<string> Tags { get; set; }
    }
}