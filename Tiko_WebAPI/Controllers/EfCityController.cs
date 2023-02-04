namespace Tiko_WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EfCityController : ControllerBase
{
    private readonly IEfCityService _efCityService;
    private readonly IMemoryCache _memoryCache;

    public EfCityController(IEfCityService efCityService, IMemoryCache memoryCache)
    {
        _efCityService = efCityService;
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

        await _efCityService.CreateCityAsync(city);
        return Created("add", city);
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<City>>> ListCities()
    {
        if (_memoryCache.TryGetValue("cities", out List<City> cities)) return Ok(cities);

        cities = await _efCityService.ListCitiesAsync();

        _memoryCache.Set("cities", cities, new MemoryCacheEntryOptions());

        return Ok(cities);
    }
}