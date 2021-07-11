using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_DataAccess.Concrete.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseServiceEf _houseService;

        public HouseController(IHouseServiceEf houseService, TikoDbContext context)
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
        public async Task<ActionResult<List<City>>> ListHousesByAgent([FromRoute] int agentId)
        {
            var houses = await _houseService.ListHousesByAgentIdAsync(agentId);
            return Ok(houses);
        }

        [HttpGet("listByCity/{cityId:int}")]
        public async Task<ActionResult<List<City>>> ListHousesByCity([FromRoute] int cityId)
        {
            var houses = await _houseService.ListHousesByCityIdAsync(cityId);
            return Ok(houses);
        }

        [HttpPut("updatePrice/{houseId:int}&setPrice={newPrice:int}")]
        public async Task<ActionResult> UpdateHousePrice([FromRoute] int houseId, [FromRoute] int newPrice)
        {
            House houseToUpdate = await _houseService.GetHouseById(houseId);
            await _houseService.UpdateHousePriceAsync(houseToUpdate, newPrice);
            return NoContent();
        }

        [HttpDelete("remove/{houseId:int}")]
        public async Task<ActionResult> RemoveHouse([FromRoute] int houseId)
        {
            House houseToDelete = await _houseService.GetHouseById(houseId);
            await _houseService.DeleteHouseAsync(houseToDelete);
            return NoContent();
        }
    }
}