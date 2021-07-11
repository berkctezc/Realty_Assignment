using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract.Dapper
{
    public interface IAgentServiceDp
    {
        Task CreateAgentAsync(Agent agent);

        Task<Agent> GetAgentByIdAsync(int id);

        Task<List<Agent>> ListAgentsAsync();

        Task DeleteAgentAsync(Agent agent);
    }
}