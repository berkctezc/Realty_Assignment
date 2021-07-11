using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_Business.Concrete.EntityFramework
{
    public class AgentManager : IAgentServiceEf
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

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            return await _agentDal.GetAsync(a => a.Id == id);
        }

        public async Task<List<Agent>> ListAgentsAsync()
        {
            return await _agentDal.GetAllAsync();
        }

        public async Task<List<AgentDetail>> ListAgentDetailsAsync()
        {
            return await _agentDal.GetAgentDetails();
        }

        public async Task DeleteAgentAsync(Agent agent)
        {
            await _agentDal.DeleteAsync(agent);
        }
    }
}