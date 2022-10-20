using Ms.Inventory.BusinessLogic.Blo.Inventory;
using System.Collections.Generic;

namespace Ms.Inventory.BusinessLogic.Contracts.Inventory
{
    public interface IInventoryDataService
    {
        void SaveInventoryData(InventoryDataBlo inventoryDataBlo);
        IEnumerable<InventoryPerProductBlo> GetInventoryCountGroupedByProductAndInventoryId();
        IEnumerable<InventoryProductPerDayBlo> GetInventoryCountGroupedByProductPerDay();
        Dictionary<string, int> GetInventoryCountGroupedByCompany();
    }
}