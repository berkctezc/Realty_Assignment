using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_Business.Abstract.Dapper
{
    public interface IDpAgentService
    {
        Task CreateAgentAsync(Agent agent);

        Task<Agent> GetAgentByIdAsync(int id);

        Task<List<Agent>> ListAgentsAsync();

        Task<List<AgentDetail>> ListAgentDetailsAsync();

        Task DeleteAgentAsync(Agent agent);
    }
}