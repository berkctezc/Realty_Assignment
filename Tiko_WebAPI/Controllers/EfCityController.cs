using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfCityController : ControllerBase
    {
        private readonly IEfCityService _efCityService;

        public EfCityController(IEfCityService efCityService)
        {
            _efCityService = efCityService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCity([FromBody] City city)
        {
            await _efCityService.CreateCityAsync(city);
            return Created("add", city);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<City>>> ListCities()
        {
            var cities = await _efCityService.ListCitiesAsync();
            return Ok(cities);
        }
    }
}