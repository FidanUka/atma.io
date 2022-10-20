using Ms.Inventory.Dto.Inventory;
using Ms.Inventory.Dto.Product;
using System.Threading.Tasks;

namespace Ms.Inventory.IntegrationTests.Common
{
    public static class Requests
    {
        private static readonly string BaseUrl = "https://localhost:5001";

        public static async Task<R> PostProduct<R>(ProductDto product, bool returnsException = false, bool emptyResponse = false)
        {
            var url = BaseUrl + $"/product";
            var response = await RequestDriver.PostAsync<ProductDto, R>(url, product, returnsException: returnsException, emptyResponse: emptyResponse);
            return response;
        }

        public static async Task<R> PostInventory<R>(InventoryDataDto inventory, bool returnsException = false, bool emptyResponse = false)
        {
            var url = BaseUrl + $"/inventory";
            var response = await RequestDriver.PostAsync<InventoryDataDto, R>(url, inventory, returnsException: returnsException, emptyResponse: emptyResponse);
            return response;
        }

        public static async Task<R> GetInventoryGroupedByCompany<R>()
        {
            var url = BaseUrl + $"/inventory/counts/company/products";
            var response = await RequestDriver.GetAsync<R>(url);
            return response;
        }

        public static async Task<R> GetInventoryGroupedByProductPerDay<R>()
        {
            var url = BaseUrl + $"/inventory/counts/daily/products";
            var response = await RequestDriver.GetAsync<R>(url);
            return response;
        }

        public static async Task<R> GetInventoryGroupedByProductAndInventory<R>()
        {
            var url = BaseUrl + $"/inventory/counts/products";
            var response = await RequestDriver.GetAsync<R>(url);
            return response;
        }

    }
}