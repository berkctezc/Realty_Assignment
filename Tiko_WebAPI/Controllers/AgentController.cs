using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract;
using Tiko_DataAccess.Concrete.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;
        private readonly TikoDbContext _context;

        public AgentController(IAgentService agentService, TikoDbContext context)
        {
            _agentService = agentService;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddAgent([FromBody] Agent agent)
        {
            await _agentService.CreateAgentAsync(agent);
            return Created("add", agent);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<City>>> ListAgents()
        {
            var agents = await _agentService.ListAgentsAsync();
            return Ok(agents);
        }

        [HttpDelete("remove/{agentId:int}")]
        public async Task<ActionResult> RemoveAgent([FromRoute] int agentId)
        {
            Agent agentToDelete = await _context.Agents.SingleAsync(x => x.Id == agentId);
            await _agentService.DeleteAgentAsync(agentToDelete);
            return NoContent();
        }
    }
}