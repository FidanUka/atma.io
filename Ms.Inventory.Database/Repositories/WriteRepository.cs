using Ms.Inventory.Database.Contracts.Repositories;
using Ms.Inventory.Database.Rto.Inventory;
using Ms.Inventory.Database.Rto.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ms.Inventory.Database.Repositories
{
    public class WriteRepository : IWriteRepository
    {
        private Dictionary<string, ProductRto> products = new Dictionary<string, ProductRto>();
        private Dictionary<string, InventoryDataRto> inventory = new Dictionary<string, InventoryDataRto>();
        public async Task SaveInventoryDataAsync(InventoryDataRto inventoryDataRto)
        {
            try
            {
                await Task.Run(() => inventory.Add(inventoryDataRto.InventoryId, inventoryDataRto));
            }
            catch (Exception)
            {
                //log reason
                throw new Exception("Saving data to repository failed!");
            }
        }

        public async Task SaveProductAsync(ProductRto productRto)
        {
            try
            {
                await Task.Run(() => products.Add(productRto.CompanyPrefix + productRto.ItemReference.ToString(), productRto));
            }
            catch (Exception)
            {
                //log reason
                throw new Exception("Saving data to repository failed!");
            }
        }
    }
}