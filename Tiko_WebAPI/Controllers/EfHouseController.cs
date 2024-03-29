﻿namespace Tiko_WebAPI.Controllers;

[Route("api/[controller]"), ApiController]
public class EfHouseController : ControllerBase
{
    private readonly IEfHouseService _efHouseService;

    public EfHouseController(IEfHouseService efHouseService)
        => _efHouseService = efHouseService;

    [HttpPost("add")]
    public async Task<ActionResult> AddHouse([FromBody] House house)
    {
        await _efHouseService.CreateHouseAsync(house);
        return Created("add", house);
    }

    [HttpGet("listByAgent/{agentId:int}")]
    public async Task<ActionResult<List<House>>> ListHousesByAgent([FromRoute] int agentId)
    {
        var houses = await _efHouseService.ListHousesByAgentIdAsync(agentId);
        return Ok(houses);
    }

    [HttpGet("listByCity/{cityId:int}")]
    public async Task<ActionResult<List<House>>> ListHousesByCity([FromRoute] int cityId)
    {
        var houses = await _efHouseService.ListHousesByCityIdAsync(cityId);
        return Ok(houses);
    }

    [HttpGet("listDetailsByAgent/{agentId:int}")]
    public async Task<ActionResult<List<HouseDetail>>> ListHouseDetailsByAgent([FromRoute] int agentId)
    {
        var houses = await _efHouseService.ListHouseDetailsByAgentIdAsync(agentId);
        return Ok(houses);
    }

    [HttpGet("listDetailsByCity/{cityId:int}")]
    public async Task<ActionResult<List<HouseDetail>>> ListHouseDetailsByCity([FromRoute] int cityId)
    {
        var houses = await _efHouseService.ListHouseDetailsByCityIdAsync(cityId);
        return Ok(houses);
    }

    [HttpPut("updatePrice/{houseId:int}&setPrice={newPrice:int}")]
    public async Task<ActionResult> UpdateHousePrice([FromRoute] int houseId, [FromRoute] int newPrice)
    {
        var houseToUpdate = await _efHouseService.GetHouseByIdAsync(houseId);
        await _efHouseService.UpdateHousePriceAsync(houseToUpdate, newPrice);
        return NoContent();
    }

    [HttpDelete("remove/{houseId:int}")]
    public async Task<ActionResult> RemoveHouse([FromRoute] int houseId)
    {
        var houseToDelete = await _efHouseService.GetHouseByIdAsync(houseId);
        await _efHouseService.DeleteHouseAsync(houseToDelete);
        return NoContent();
    }
}