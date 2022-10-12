using Ms.Inventory.BusinessLogic.Blo.Inventory;
using Ms.Inventory.BusinessLogic.Contracts.Inventory;
using System;
using System.Threading.Tasks;

namespace Ms.Inventory.BusinessLogic.Inventory
{
    public class InventoryDataService : IInventoryDataService
    {
        public async Task<int> GetInventoryCountByCompanyAsync(string company)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetInventoryCountByProductAndInventoryIdAsync(long itemReference, string inventoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetInventoryCountByProductPerDayAsync(long itemReference)
        {
            throw new NotImplementedException();
        }

        public async Task SaveInventoryDataAsync(InventoryDataBlo inventoryDataBlo)
        {
            throw new NotImplementedException();
        }
    }
}