using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfAgentController : ControllerBase
    {
        private readonly IEfAgentService _efAgentService;
        private readonly IMemoryCache _memoryCache;

        public EfAgentController(IEfAgentService efAgentService, IMemoryCache memoryCache)
        {
            _efAgentService = efAgentService;
            _memoryCache = memoryCache;
        }


        [HttpPost("add")]
        public async Task<ActionResult> AddAgent([FromBody] Agent agent)
        {
            _memoryCache.Remove("agents");
            _memoryCache.Remove("agentDetails");

            await _efAgentService.CreateAgentAsync(agent);
            return Created("add", agent);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<Agent>>> ListAgents()
        {
            if (_memoryCache.TryGetValue("agents", out List<Agent> agents))
                return Ok(agents);

            agents = await _efAgentService.ListAgentsAsync();

            _memoryCache.Set("agents", agents, new MemoryCacheEntryOptions());

            return Ok(agents);
        }

        [HttpGet("listDetails")]
        public async Task<ActionResult<List<AgentDetail>>> ListAgentDetails()
        {
            if (_memoryCache.TryGetValue("agentDetails", out List<AgentDetail> agentDetails))
                return Ok(agentDetails);

            agentDetails = await _efAgentService.ListAgentDetailsAsync();

            _memoryCache.Set("agentDetails", agentDetails, new MemoryCacheEntryOptions());

            return Ok(agentDetails);
        }

        [HttpDelete("remove/{agentId:int}")]
        public async Task<ActionResult> RemoveAgent([FromRoute] int agentId)
        {
            _memoryCache.Remove("agents");
            _memoryCache.Remove("agentDetails");

            Agent agentToDelete = await _efAgentService.GetAgentByIdAsync(agentId);
            await _efAgentService.DeleteAgentAsync(agentToDelete);
            return NoContent();
        }
    }
}