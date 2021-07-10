using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
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
        private readonly IHouseServiceDp  _houseService;
        private readonly SqliteConnection _db;

        public DpHouseController(IHouseServiceDp houseService, IConfiguration config)
        {
            _houseService = houseService;
            this._db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));
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
            var houses = await Task.Run(()=>_houseService.ListHousesByAgentId(agentId));
            return Ok(houses);
        }

        [HttpGet("listByCity/{cityId:int}")]
        public async Task<ActionResult<List<City>>> ListHousesByCity([FromRoute] int cityId)
        {
            var houses = await Task.Run(()=>_houseService.ListHousesByCityId(cityId));
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
            await _houseService.DeleteHouseAsync(_db.Get<House>(houseId));
            return NoContent();
        }
    }
}