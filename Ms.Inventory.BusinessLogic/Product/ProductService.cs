using AutoMapper;
using Ms.Inventory.BusinessLogic.Blo.Product;
using Ms.Inventory.BusinessLogic.Contracts.Product;
using Ms.Inventory.Database.Contracts.Repositories;
using Ms.Inventory.Database.Rto.Product;

namespace Ms.Inventory.BusinessLogic.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void SaveProduct(ProductBlo productBlo)
        {
            var productRto = _mapper.Map<ProductRto>(productBlo);
            _repository.SaveProduct(productRto);
        }
    }
}