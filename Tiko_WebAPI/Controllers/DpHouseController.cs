using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DpHouseController : ControllerBase
    {
        private readonly IHouseServiceDp _houseService;

        public DpHouseController(IHouseServiceDp houseService)
        {
            _houseService = houseService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddHouse([FromBody] House house)
        {
            await _houseService.CreateHouseAsync(house);
            return Created("add", house);
        }

        [HttpGet("listByAgent/{agentId:int}")]
        public async Task<ActionResult<List<House>>> ListHousesByAgent([FromRoute] int agentId)
        {
            var houses = await Task.Run(() => _houseService.ListHousesByAgentIdAsync(agentId));
            return Ok(houses);
        }

        [HttpGet("listByCity/{cityId:int}")]
        public async Task<ActionResult<List<House>>> ListHousesByCity([FromRoute] int cityId)
        {
            var houses = await Task.Run(() => _houseService.ListHousesByCityIdAsync(cityId));
            return Ok(houses);
        }      
        
        [HttpGet("listDetailsByAgent/{agentId:int}")]
        public async Task<ActionResult<List<House>>> ListHouseDetailsByAgent([FromRoute] int agentId)
        {
            var houses = await Task.Run(() => _houseService.ListHouseDetailsByAgentIdAsync(agentId));
            return Ok(houses);
        }

        [HttpGet("listDetailsByCity/{cityId:int}")]
        public async Task<ActionResult<List<House>>> ListHouseDetailsByCity([FromRoute] int cityId)
        {
            var houses = await Task.Run(() => _houseService.ListHouseDetailsByCityIdAsync(cityId));
            return Ok(houses);
        }

        [HttpPut("updatePrice/{houseId:int}&setPrice={newPrice:int}")]
        public async Task<ActionResult> UpdateHousePrice([FromRoute] int houseId, [FromRoute] int newPrice)
        {
            await _houseService.UpdateHousePriceAsync(houseId, newPrice);
            return NoContent();
        }

        [HttpDelete("remove/{houseId:int}")]
        public async Task<ActionResult> RemoveHouse([FromRoute] int houseId)
        {
            House houseToRemove = await _houseService.GetHouseByIdAsync(houseId);
            await _houseService.DeleteHouseAsync(houseToRemove);
            return NoContent();
        }
    }
}