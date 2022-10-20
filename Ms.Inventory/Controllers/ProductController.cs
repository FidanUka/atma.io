using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ms.Inventory.BusinessLogic.Blo.Product;
using Ms.Inventory.BusinessLogic.Contracts.Product;
using Ms.Inventory.Dto.Product;

namespace Ms.Inventory.Controllers
{
    /// <summary>
    /// Product controller provides the endpoint to add product data
    /// </summary>
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

        /// <summary>
        /// Save inventory data
        /// </summary>
        /// <param name="productDto">The object with product data</param>
        /// <returns code="200">if data saved successfuly</returns>
        [HttpPost]
        public ActionResult AddProduct([FromBody] ProductDto productDto)
        {
            var productBlo = _mapper.Map<ProductBlo>(productDto);
            _productService.SaveProduct(productBlo);
            return Ok();
        }
    }
}