using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ms.Inventory.BusinessLogic.Blo.Inventory;
using Ms.Inventory.BusinessLogic.Contracts.Inventory;
using Ms.Inventory.Dto.Inventory;
using System.Collections.Generic;

namespace Ms.Inventory.Controllers
{
    /// <summary>
    /// Inventory controller provides the endpoints to add and fetch inventory data
    /// </summary>
    [Route("inventory")]
    public class InventoryController : Controller
    {
        private readonly IInventoryDataService _inventoryDataService;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryDataService inventoryDataService,
            IMapper mapper)
        {
            _inventoryDataService = inventoryDataService;
            _mapper = mapper;
        }

        /// <summary>
        /// Save inventory data
        /// </summary>
        /// <param name="inventoryDataDto">The object with inventory data</param>
        /// <returns code="200">if data saved successfuly</returns>
        [HttpPost]
        public ActionResult AddInventoryData([FromBody] InventoryDataDto inventoryDataDto)
        {
            if(inventoryDataDto.InventoryId.Length > 32)
            {
                return BadRequest("Inventory Id should not be longer than 32 characters");
            }
            var inventoryDataBlo = _mapper.Map<InventoryDataBlo>(inventoryDataDto);
            _inventoryDataService.SaveInventoryData(inventoryDataBlo);
            return Ok();
        }

        /// <summary>
        /// Fetchs the count of products per inventory
        /// </summary>
        /// <returns code="200">if data are queried successfully</returns>
        [HttpGet, Route("counts/products")]
        public ActionResult<IEnumerable<InventoryPerProductDto>> GetInventoryData()
        {
            var inventoryPerProductBlo = _inventoryDataService.GetInventoryCountGroupedByProductAndInventoryId();
            var inventoryPerProductDto = _mapper.Map<IEnumerable<InventoryPerProductDto>>(inventoryPerProductBlo);
            return Ok(inventoryPerProductDto);
        }

        /// <summary>
        /// Fetchs the count of products per day
        /// </summary>
        /// <returns code="200">if data are queried successfully</returns>
        [HttpGet, Route("counts/daily/products")]
        public ActionResult<IEnumerable<InventoryProductPerDayDto>> GetInventoryProductDataPerDay()
        {
            var inventoryProductPerDayBlo = _inventoryDataService.GetInventoryCountGroupedByProductPerDay();
            var inventoryProductPerDayDto = _mapper.Map<IEnumerable<InventoryProductPerDayDto>>(inventoryProductPerDayBlo);
            return Ok(inventoryProductPerDayDto);
        }

        /// <summary>
        /// Fetchs the count of products per company
        /// </summary>
        /// <returns code="200">if data are queried successfully</returns>
        [HttpGet, Route("counts/company/products")]
        public ActionResult<Dictionary<string, int>> GetInventoryDataPerCompany()
        {
            var result = _inventoryDataService.GetInventoryCountGroupedByCompany();
            return Ok(result);
        }
    }
}