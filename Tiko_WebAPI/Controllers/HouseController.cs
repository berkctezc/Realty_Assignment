﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tiko_Business.Abstract;
using Tiko_Entities.Concrete;
using Tiko_WebAPI.Data;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;
        private readonly TikoDbContext _context;


        public HouseController(IHouseService houseService, TikoDbContext context)
        {
            _houseService = houseService;
            _context = context;
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

        [HttpPut("updatePrice/{houseId:int}")]
        public async Task<ActionResult> UpdateHousePrice([FromRoute] int houseId, [FromBody] int newPrice)
        {
            House houseToUpdate = await _context.Houses.SingleAsync(x => x.Id == houseId);
            await _houseService.UpdateHousePriceAsync(houseToUpdate, newPrice);
            return NoContent();
        }

        [HttpDelete("remove/{houseId:int}")]
        public async Task<ActionResult> RemoveHouse([FromRoute] int houseId)
        {
            House houseToDelete = await _context.Houses.SingleAsync(x => x.Id == houseId);
            await _houseService.DeleteHouseAsync(houseToDelete);
            return NoContent();
        }
    }
}