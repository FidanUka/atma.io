using System;
using System.Collections.Generic;

namespace Ms.Inventory.Dto.Inventory
{
    public class InventoryDataDto
    {
        public string InventoryId { get; set; }
        public int ItemReference { get; set; } 
        public string Location { get; set; }
        public DateTimeOffset DateOfInventory { get; set; }
        public HashSet<string> Tags { get; set; }
    }
}