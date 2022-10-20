using System;

namespace Ms.Inventory.Dto.Inventory
{
    /// <summary>
    /// InventoryProductPerDayDto
    /// </summary>
    public class InventoryProductPerDayDto
    {
        /// <summary>
        /// This filed contains product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// This filed contains the date the product inventory
        /// </summary>
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        /// This filed contains the count of items for the specified date and product
        /// </summary>
        public int Items { get; set; }
    }
}