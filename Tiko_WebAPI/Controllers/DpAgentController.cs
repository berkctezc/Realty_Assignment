using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IDpAgentService _dpAgentService;
        private readonly IMemoryCache _memoryCache;

        public DpAgentController(IDpAgentService dpAgentService, IMemoryCache memoryCache)
        {
            _dpAgentService = dpAgentService;
            _memoryCache = memoryCache;
        }

        private void Remover()
        {
            string[] cachedList = { "agents", "agentDetails" };
            foreach (var cached in cachedList) _memoryCache.Remove(cached);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddAgent([FromBody] Agent agent)
        {
            Remover();

            await _dpAgentService.CreateAgentAsync(agent);
            return Created("add", agent);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<Agent>>> ListAgents()
        {
            if (_memoryCache.TryGetValue("agents", out List<Agent> agents)) return Ok(agents);

            agents = await _dpAgentService.ListAgentsAsync();

            _memoryCache.Set("agents", agents, new MemoryCacheEntryOptions());

            return Ok(agents);
        }

        [HttpGet("listDetails")]
        public async Task<ActionResult<List<AgentDetail>>> ListAgentDetails()
        {
            if (_memoryCache.TryGetValue("agentDetails", out List<AgentDetail> agentDetails)) return Ok(agentDetails);

            var agents = await _dpAgentService.ListAgentDetailsAsync();

            _memoryCache.Set("agentDetails", agentDetails, new MemoryCacheEntryOptions());

            return Ok(agents);
        }

        [HttpDelete("remove/{agentId:int}")]
        public async Task<ActionResult> RemoveAgent([FromRoute] int agentId)
        {
            Remover();

            var agentToRemove = await _dpAgentService.GetAgentByIdAsync(agentId);

            await _dpAgentService.DeleteAgentAsync(agentToRemove);

            return NoContent();
        }
    }
}