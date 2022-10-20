namespace Ms.Inventory.Dto.Inventory
{
    /// <summary>
    /// InventoryPerProductDto
    /// </summary>
    public class InventoryPerProductDto
    {
        /// <summary>
        /// This filed contains product name
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// This filed contains the inventory id
        /// </summary>
        public string InventoryId { get; set; }
        /// <summary>
        /// This filed contains the count of items for the specified product
        /// </summary>
        public int Items { get; set; }
    }
}