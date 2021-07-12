using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;
using Tiko_WebAPI.Extensions;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentServiceEf _agentService;
        private readonly IMemoryCache _memoryCache;

        public AgentController(IAgentServiceEf agentService, IMemoryCache memoryCache)
        {
            _agentService = agentService;
            _memoryCache = memoryCache;
        }


        [HttpPost("add")]
        public async Task<ActionResult> AddAgent([FromBody] Agent agent)
        {
            _memoryCache.Remove("agents");
            _memoryCache.Remove("agentDetails");

            await _agentService.CreateAgentAsync(agent);
            return Created("add", agent);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<Agent>>> ListAgents()
        {
            if (_memoryCache.TryGetValue("agents", out List<Agent> agents))
                return Ok(agents);

            agents = await _agentService.ListAgentsAsync();

            _memoryCache.Set("agents", agents, new MemoryCacheEntryOptions());

            return Ok(agents);
        }

        [HttpGet("listDetails")]
        public async Task<ActionResult<List<AgentDetail>>> ListAgentDetails()
        {
            if (_memoryCache.TryGetValue("agentDetails", out List<AgentDetail> agentDetails))
                return Ok(agentDetails);

            agentDetails = await _agentService.ListAgentDetailsAsync();

            _memoryCache.Set("agentDetails", agentDetails, new MemoryCacheEntryOptions());

            return Ok(agentDetails);
        }

        [HttpDelete("remove/{agentId:int}")]
        public async Task<ActionResult> RemoveAgent([FromRoute] int agentId)
        {
            _memoryCache.Remove("agents");
            _memoryCache.Remove("agentDetails");

            Agent agentToDelete = await _agentService.GetAgentByIdAsync(agentId);
            await _agentService.DeleteAgentAsync(agentToDelete);
            return NoContent();
        }
    }
}