using Ms.Inventory.BusinessLogic.Blo.Inventory;
using System.Threading.Tasks;

namespace Ms.Inventory.BusinessLogic.Contracts.Inventory
{
    public interface IInventoryDataService
    {
        Task SaveInventoryDataAsync(InventoryDataBlo inventoryDataBlo);
        Task<int> GetInventoryCountByProductAndInventoryIdAsync(int itemReference, string inventoryId);
        Task<int> GetInventoryCountByProductPerDayAsync(int itemReference);
        Task<int> GetInventoryCountByCompanyAsync(string company);
    }
}