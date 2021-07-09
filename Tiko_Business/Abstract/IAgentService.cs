using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract
{
    public interface IAgentService
    {
        Task CreateAgentAsync(Agent agent);

        Task<List<Agent>> ListAgentsAsync();

        Task DeleteAgentAsync(Agent agent);
    }
}