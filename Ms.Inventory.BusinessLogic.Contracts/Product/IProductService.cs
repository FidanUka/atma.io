using Ms.Inventory.BusinessLogic.Blo.Product;
using System.Threading.Tasks;

namespace Ms.Inventory.BusinessLogic.Contracts.Product
{
    public interface IProductService
    {
        Task SaveProduct(ProductBlo productBlo);
    }
}