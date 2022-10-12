using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ms.Inventory.BusinessLogic.Blo.Inventory;
using Ms.Inventory.BusinessLogic.Contracts.Inventory;
using Ms.Inventory.Dto.Inventory;
using System.Threading.Tasks;

namespace Ms.Inventory.Controllers
{
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

        [HttpPost]
        public async Task<ActionResult> AddInventoryData([FromBody] InventoryDataDto inventoryDataDto)
        {
            var inventoryDataBlo = _mapper.Map<InventoryDataBlo>(inventoryDataDto);
            await _inventoryDataService.SaveInventoryDataAsync(inventoryDataBlo);
            return Ok();
        }

        [HttpGet, Route("{itemReference}/{inventoryId}")]
        public async Task<ActionResult<int>> GetInventoryData([FromRoute] long itemReference, [FromRoute] string inventoryId)
        {
            int count = await _inventoryDataService.GetInventoryCountByProductAndInventoryIdAsync(itemReference, inventoryId);
            return Ok(count);
        }
            
        [HttpGet, Route("{itemReference}")]
        public async Task<ActionResult<int>> GetInventoryData([FromRoute] long itemReference)
        {
            int count = await _inventoryDataService.GetInventoryCountByProductPerDayAsync(itemReference);
            return Ok(count);
        }
            
        [HttpGet, Route("{company}")]
        public async Task<ActionResult<int>> GetInventoryData([FromRoute] string company)
        {
            int count = await _inventoryDataService.GetInventoryCountByCompanyAsync(company);
            return Ok(count);
        }
    }
}