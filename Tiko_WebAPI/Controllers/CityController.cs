using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Common;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCity([FromBody] City city)
        {
            await _cityService.CreateCityAsync(city);
            return Created("add", city);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<City>>> ListCities()
        {
            var cities = await _cityService.ListCitiesAsync();
            return Ok(cities);
        }
    }
}