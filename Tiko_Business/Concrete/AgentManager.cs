using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Concrete
{
    public class AgentManager : IAgentService
    {
        private readonly IAgentDal _agentDal;

        public AgentManager(IAgentDal agentDal)
        {
            _agentDal = agentDal;
        }

        public async Task CreateAgentAsync(Agent agent)
        {
            await _agentDal.CreateAsync(agent);
        }

        public async Task<List<Agent>> ListAgentsAsync()
        {
            return await _agentDal.GetAllAsync();
        }

        public async Task DeleteAgentAsync(Agent agent)
        {
            await _agentDal.DeleteAsync(agent);
        }
    }
}