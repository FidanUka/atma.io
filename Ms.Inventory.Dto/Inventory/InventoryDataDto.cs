using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ms.Inventory.Dto.Inventory
{
    public class InventoryDataDto
    {
        [StringLength(32, ErrorMessage = "Inventory Id should not be longer than 32 characters")]
        public string InventoryId { get; set; }
        public long ItemReference { get; set; } 
        public string Location { get; set; }
        public DateTimeOffset DateOfInventory { get; set; }
        public HashSet<string> Tags { get; set; }
    }
}