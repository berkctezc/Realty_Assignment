using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfCityController : ControllerBase
    {
        private readonly IEfCityService _efCityService;
        private readonly IMemoryCache _memoryCache;

        public EfCityController(IEfCityService efCityService,IMemoryCache memoryCache)
        {
            _efCityService = efCityService;
            _memoryCache = memoryCache;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCity([FromBody] City city)
        {
            _memoryCache.Remove("cities");

            await _efCityService.CreateCityAsync(city);
            return Created("add", city);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<City>>> ListCities()
        {
            if (_memoryCache.TryGetValue("cities", out List<City> cities))
                return Ok(cities);

            cities = await _efCityService.ListCitiesAsync();

            _memoryCache.Set("cities", cities, new MemoryCacheEntryOptions());

            return Ok(cities);
        }
    }
}