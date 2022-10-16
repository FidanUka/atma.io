using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ms.Inventory.BusinessLogic.Blo.Product;
using Ms.Inventory.BusinessLogic.Contracts.Product;
using Ms.Inventory.Dto.Product;
using System.Threading.Tasks;

namespace Ms.Inventory.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var productBlo = _mapper.Map<ProductBlo>(productDto);
            await _productService.SaveProducAsync(productBlo);
            return Ok();
        }
    }
}