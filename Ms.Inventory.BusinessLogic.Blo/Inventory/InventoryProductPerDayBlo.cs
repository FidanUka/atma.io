using System;

namespace Ms.Inventory.BusinessLogic.Blo.Inventory
{
    public class InventoryProductPerDayBlo
    {
        public string ProductName { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public int Items { get; set; }
    }
}