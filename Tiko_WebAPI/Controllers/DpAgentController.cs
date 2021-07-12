using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DpAgentController : ControllerBase
    {
        private readonly IAgentServiceDp _agentService;

        public DpAgentController(IAgentServiceDp agentService, IConfiguration config)
        {
            _agentService = agentService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddAgent([FromBody] Agent agent)
        {
            await _agentService.CreateAgentAsync(agent);
            return Created("add", agent);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<Agent>>> ListAgents()
        {
            var agents = await _agentService.ListAgentsAsync();
            return Ok(agents);
        }

        [HttpGet("listDetails")]
        public async Task<ActionResult<List<AgentDetail>>> ListAgentDetails()
        {
            var agents = await _agentService.ListAgentDetailsAsync();
            return Ok(agents);
        }

        [HttpDelete("remove/{agentId:int}")]
        public async Task<ActionResult> RemoveAgent([FromRoute] int agentId)
        {
            Agent agentToRemove = await _agentService.GetAgentByIdAsync(agentId);
            await _agentService.DeleteAgentAsync(agentToRemove);
            return NoContent();
        }
    }
}