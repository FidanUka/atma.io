using Ms.Inventory.BusinessLogic.Blo.Product;

namespace Ms.Inventory.BusinessLogic.Contracts.Product
{
    public interface IProductService
    {
        void SaveProduct(ProductBlo productBlo);
    }
}