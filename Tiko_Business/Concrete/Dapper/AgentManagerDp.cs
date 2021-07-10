using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Concrete.Dapper
{
    public class AgentManagerDp : IAgentServiceDp
    {
        private readonly IAgentDalDp _agentDalDp;

        public AgentManagerDp(IAgentDalDp agentDalDp)
        {
            _agentDalDp = agentDalDp;
        }

        public async Task CreateAgentAsync(Agent agent)
        {
            await _agentDalDp.CreateAsync(agent);
        }

        public async Task<List<Agent>> ListAgentsAsync()
        {
            return await _agentDalDp.GetAllAsync();
        }

        public async Task DeleteAgentAsync(Agent agent)
        {
            await _agentDalDp.DeleteAsync(agent);
        }
    }
}