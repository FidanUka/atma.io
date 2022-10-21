using Ms.Inventory.Dto.Inventory;
using Ms.Inventory.Dto.Product;
using System;
using System.Collections.Generic;

namespace Ms.Inventory.Shared.Helpers
{
    public static class InventoryHelper
    {
        public static (List<ProductDto> products, List<InventoryDataDto> inventory) CreateInventory(int numberOfCompanies, int numberOfProductsPerCompany, int numberOfInventoryPerProduct, int numberOfItemsPerInventory)
        {
            var products = new List<ProductDto>();
            var inventoryList = new List<InventoryDataDto>();

            for (int c = 1; c <= numberOfCompanies; c++)
            {
                for (int p = 1; p <= numberOfProductsPerCompany; p++)
                {
                    var product = new ProductDto
                    {
                        CompanyName = $"Company-{c}",
                        CompanyPrefix = 30 + c,
                        ItemReference = int.Parse(c.ToString() + "0000") + p,
                        ProductName = $"Product-{int.Parse(c.ToString() + "00") + p}",
                    };
                    products.Add(product);

                    for (int ip = 1; ip <= numberOfInventoryPerProduct; ip++)
                    {
                        var inventory = new InventoryDataDto
                        {
                            DateOfInventory = DateTime.Now.AddDays(ip),
                            InventoryId = $"Inventory-{c}-{p}-{ip}",
                            ItemReference = product.ItemReference,
                            Location = "LocationA",
                            Tags = new HashSet<string>()
                        };
                        inventoryList.Add(inventory);

                        for (int i = 1; i <= numberOfItemsPerInventory; i++)
                        {
                            inventory.Tags.Add($"{product.CompanyPrefix}{product.ItemReference}0000{ip}0{i}");
                        }
                    }
                }
            }

            return (products, inventoryList);
        }
    }
}