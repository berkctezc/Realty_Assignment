using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;

        public DpCityController(IDpCityService dpCityService, IMemoryCache memoryCache)
        {
            _dpCityService = dpCityService;
            _memoryCache = memoryCache;
        }

        private void Remover()
        {
            string[] cachedList = { "cities" };
            foreach (var cached in cachedList) _memoryCache.Remove(cached);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCity([FromBody] City city)
        {
            Remover();

            await _dpCityService.CreateCityAsync(city);
            return Created("add", city);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<City>>> ListCities()
        {
            if (_memoryCache.TryGetValue("cities", out List<City> cities)) return Ok(cities);

            cities = await _dpCityService.ListCitiesAsync();

            _memoryCache.Set("cities", cities, new MemoryCacheEntryOptions());

            return Ok(cities);
        }
    }
}