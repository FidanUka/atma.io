using System.Collections.Generic;

namespace Ms.Inventory.Database.Rto.Inventory
{
    public class InventoryPerCompanyRto
    {
        public string CompanyName { get; set; }
        public IEnumerable<InventoryDataRto> Inventory { get; set; }
    }
}