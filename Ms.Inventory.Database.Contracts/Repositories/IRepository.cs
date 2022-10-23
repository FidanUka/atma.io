using Ms.Inventory.Database.Rto.Inventory;
using Ms.Inventory.Database.Rto.Product;
using System.Collections.Generic;

namespace Ms.Inventory.Database.Contracts.Repositories
{
    public interface IRepository
    {
        void SaveProduct(ProductRto productRto);
        void SaveInventoryData(InventoryDataRto inventoryDataRto);
        IEnumerable<InventoryPerCompanyRto> GetInventoriedItemsGroupedByCompany();
        IEnumerable<InventoryPerProductRto> GetInventoriedItemsGroupedByProduct();
        IEnumerable<ProductRto> GetProducts();
        void ClearData();
    }
}