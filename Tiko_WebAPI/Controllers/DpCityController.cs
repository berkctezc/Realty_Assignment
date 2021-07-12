using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DpCityController : ControllerBase
    {
        private readonly IDpCityService _dpCityService;

        public DpCityController(IDpCityService dpCityService)
        {
            _dpCityService = dpCityService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCity([FromBody] City city)
        {
            await _dpCityService.CreateCityAsync(city);
            return Created("add", city);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<City>>> ListCities()
        {
            var cities = await _dpCityService.ListCitiesAsync();
            return Ok(cities);
        }
    }
}