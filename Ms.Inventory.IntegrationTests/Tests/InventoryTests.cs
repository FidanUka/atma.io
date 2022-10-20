using AutoFixture;
using Ms.Inventory.Dto.Inventory;
using Ms.Inventory.Dto.Product;
using Ms.Inventory.IntegrationTests.Common;
using Ms.Inventory.Shared.Helpers;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ms.Inventory.IntegrationTests.Tests
{
    [TestFixture]
    public class InventoryTests : TestBaseSetup
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public async Task CreateInventoryData_SaveInventory_ReturnsSuccess()
        {
            //Arrange
            ProductDto product = new ProductDto()
            {
                CompanyName = "ABCDE",
                CompanyPrefix = 32,
                ItemReference = 1234567890,
                ProductName = "ProductName1234"
            };
            await Requests.PostProduct<string>(product, emptyResponse: true);

            var tags = _fixture.Build<string>().CreateMany();

            InventoryDataDto inventory = new InventoryDataDto()
            {
                InventoryId = "Inventory123",
                ItemReference = product.ItemReference,
                Location = "LocationA",
                DateOfInventory = DateTimeOffset.UtcNow,
                Tags = tags.ToHashSet()
            };

            //Act
            var response = await Requests.PostInventory<string>(inventory, emptyResponse: true);

            //Assert
            Assert.IsNull(response); // null is success
        }

        [Test]
        public async Task GetInventory_GetInventoryGroupedByCompany_ReturnsSuccess()
        {
            //Arrange
            await InsertData();

            //Act


            //Assert

        }

        #region Helper Methods
        private async Task InsertData()
        {
            var tuple = InventoryHelper.CreateInventory(3, 5, 3, 10);

            foreach (var product in tuple.products)
            {
                await Requests.PostProduct<string>(product, emptyResponse: true);
            }

            foreach (var inventory in tuple.inventory)
            {
                await Requests.PostInventory<string>(inventory, emptyResponse: true);
            }
        }
        #endregion
    }
}
