using Ms.Inventory.Database.Rto.Inventory;
using Ms.Inventory.Database.Rto.Product;
using System.Threading.Tasks;

namespace Ms.Inventory.Database.Contracts.Repositories
{
    public interface IWriteRepository
    {
        Task SaveProductAsync(ProductRto productRto);
        Task SaveInventoryDataAsync(InventoryDataRto inventoryDataRto);
    }
}