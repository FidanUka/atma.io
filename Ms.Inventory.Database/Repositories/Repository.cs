using Ms.Inventory.Database.Contracts.Repositories;
using Ms.Inventory.Database.Rto.Inventory;
using Ms.Inventory.Database.Rto.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ms.Inventory.Database.Repositories
{
    public class Repository : IRepository
    {
        private Dictionary<string, ProductRto> products = new Dictionary<string, ProductRto>();
        private Dictionary<string, InventoryDataRto> inventory = new Dictionary<string, InventoryDataRto>();

        public IEnumerable<InventoryPerCompanyRto> GetInventoriedItemsGroupedByCompany()
        {
            try
            {
                var inventoryPerCompany = new List<InventoryPerCompanyRto>();
                var companyPrefixes = products.Values.GroupBy(x => x.CompanyPrefix);
                inventoryPerCompany.AddRange(from item in companyPrefixes
                                             let products = item.Select(x => x.ItemReference)
                                             let inevntoryItems = inventory.Values.Where(x => products.Contains(x.ItemReference))
                                             select new InventoryPerCompanyRto { CompanyName = item.FirstOrDefault().CompanyName, Inventory = inevntoryItems });
                return inventoryPerCompany;
            }
            catch (Exception)
            {
                //log here
                throw new Exception("Querying company data in repository failed");
            }
        }

        public IEnumerable<InventoryPerProductRto> GetInventoriedItemsGroupedByProduct()
        {
            try
            {
                return (from item in inventory.Values.GroupBy(x => x.ItemReference)
                        select new InventoryPerProductRto
                        {
                            ProductName = products.FirstOrDefault(x => x.Value.ItemReference == item.Key).Value.ProductName,
                            Items = item.Select(x => x)
                        }).ToList();
            }
            catch (Exception)
            {
                //log here
                throw new Exception("Quering product data in repository failed!");
            }
        }

        public void SaveInventoryData(InventoryDataRto inventoryDataRto)
        {
            try
            {
                inventory.Add(inventoryDataRto.InventoryId, inventoryDataRto);
            }
            catch (Exception)
            {
                //log reason
                throw new Exception("Saving inventory data to repository failed!");
            }
        }

        public void SaveProduct(ProductRto productRto)
        {
            try
            {
                products.Add(productRto.CompanyPrefix + productRto.ItemReference.ToString(), productRto);
            }
            catch (Exception)
            {
                //log reason
                throw new Exception("Saving product data to repository failed!");
            }
        }
    }
}