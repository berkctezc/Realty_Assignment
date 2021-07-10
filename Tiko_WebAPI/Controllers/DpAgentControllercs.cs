using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Tiko_Business.Abstract.Dapper;
using Tiko_Business.Concrete.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DpAgentController : ControllerBase
    {
        private readonly IAgentServiceDp _agentService;
        private readonly IDbConnection _db;

        public DpAgentController(IAgentServiceDp agentService, IConfiguration config)
        {
            _agentService = agentService;
            this._db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));
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
            var sql = "DELETE FROM Agents WHERE Id = @Id";

            await _db.ExecuteAsync(sql,new{@Id=agentId});

            return NoContent();
        }
    }
}
