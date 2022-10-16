using AutoMapper;
using Ms.Inventory.BusinessLogic.Blo.Product;
using Ms.Inventory.BusinessLogic.Contracts.Product;
using Ms.Inventory.Database.Contracts.Repositories;
using Ms.Inventory.Database.Rto.Product;
using System.Threading.Tasks;

namespace Ms.Inventory.BusinessLogic.Product
{
    public class ProductService : IProductService
    {
        private readonly IWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public ProductService(IWriteRepository writeRepository,
            IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task SaveProducAsync(ProductBlo productBlo)
        {
            var productRto = _mapper.Map<ProductRto>(productBlo);
            await _writeRepository.SaveProductAsync(productRto);
        }
    }
}