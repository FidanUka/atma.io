using Ms.Inventory.Dto.Product;
using Ms.Inventory.IntegrationTests.Common;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Ms.Inventory.IntegrationTests.Tests
{
    [TestFixture]
    public class ProductTests : TestBaseSetup
    {
        [Test]
        public async Task CreateProductData_SaveProduct_ReturnsSuccess()
        {
            //Arrange
            ProductDto product = new ProductDto()
            {
                CompanyName = "ABCD",
                CompanyPrefix = 31,
                ItemReference = 123456789,
                ProductName = "ProductName123"
            };

            //Act
            var response = await Requests.PostProduct<string>(product, emptyResponse: true);

            //Assert
            Assert.IsNull(response);
        }
    }
}