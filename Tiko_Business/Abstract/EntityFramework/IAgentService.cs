using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_Business.Abstract.EntityFramework
{
    public interface IAgentServiceEf
    {
        Task CreateAgentAsync(Agent agent);

        Task<Agent> GetAgentByIdAsync(int id);

        Task<List<Agent>> ListAgentsAsync();

        Task<List<AgentDetail>> ListAgentDetailsAsync();

        Task DeleteAgentAsync(Agent agent);
    }
}