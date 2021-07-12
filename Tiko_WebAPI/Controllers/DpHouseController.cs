using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Tiko_Business.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DpHouseController : ControllerBase
    {
        private readonly IDpHouseService _dpHouseService;

        public DpHouseController(IDpHouseService dpHouseService)
        {
            _dpHouseService = dpHouseService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddHouse([FromBody] House house)
        {
            await _dpHouseService.CreateHouseAsync(house);
           
            return Created("add", house);
        }


        [HttpGet("listByAgent/{agentId:int}")]
        public async Task<ActionResult<List<House>>> ListHousesByAgent([FromRoute] int agentId)
        {
            var housesByAgent = await Task.Run(() => _dpHouseService.ListHousesByAgentIdAsync(agentId));

            return Ok(housesByAgent);
        }

        [HttpGet("listByCity/{cityId:int}")]
        public async Task<ActionResult<List<House>>> ListHousesByCity([FromRoute] int cityId)
        {
            var housesByCity = await Task.Run(() => _dpHouseService.ListHousesByCityIdAsync(cityId));

            return Ok(housesByCity);
        }

        [HttpGet("listDetailsByAgent/{agentId:int}")]
        public async Task<ActionResult<List<House>>> ListHouseDetailsByAgent([FromRoute] int agentId)
        {
            var houses = await Task.Run(() => _dpHouseService.ListHouseDetailsByAgentIdAsync(agentId));
           
            return Ok(houses);
        }

        [HttpGet("listDetailsByCity/{cityId:int}")]
        public async Task<ActionResult<List<House>>> ListHouseDetailsByCity([FromRoute] int cityId)
        {
            var houses = await Task.Run(() => _dpHouseService.ListHouseDetailsByCityIdAsync(cityId));
           
            return Ok(houses);
        }

        [HttpPut("updatePrice/{houseId:int}&setPrice={newPrice:int}")]
        public async Task<ActionResult> UpdateHousePrice([FromRoute] int houseId, [FromRoute] int newPrice)
        {
            await _dpHouseService.UpdateHousePriceAsync(houseId, newPrice);
           
            return NoContent();
        }

        [HttpDelete("remove/{houseId:int}")]
        public async Task<ActionResult> RemoveHouse([FromRoute] int houseId)
        {
            var houseToRemove = await _dpHouseService.GetHouseByIdAsync(houseId);
           
            await _dpHouseService.DeleteHouseAsync(houseToRemove);
           
            return NoContent();
        }
    }
}