using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ms.Inventory.BusinessLogic.Blo.Product;
using Ms.Inventory.Dto.Product;
using System.Threading.Tasks;

namespace Ms.Inventory.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ISaveProductService _saveProductService;
        private readonly IMapper _mapper;
        public ProductController(ISaveProductService saveProductService,
            IMapper mapper)
        {
            _saveProductService = saveProductService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var productBlo = _mapper.Map<ProductBlo>(productDto);
            await _saveProductService.SaveProductAsync(productDto);
            return Ok();
        }
    }
}