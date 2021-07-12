using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_Business.Concrete.Dapper
{
    public class DpAgentManager : IDpAgentService
    {
        private readonly IDpAgentDal _dpAgentDal;

        public DpAgentManager(IDpAgentDal dpAgentDal)
        {
            _dpAgentDal = dpAgentDal;
        }

        public async Task CreateAgentAsync(Agent agent)
        {
            await _dpAgentDal.CreateAsync(agent);
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            return await _dpAgentDal.GetByIdAsync(id);
        }

        public async Task<List<Agent>> ListAgentsAsync()
        {
            return await _dpAgentDal.GetAllAsync();
        }

        public async Task<List<AgentDetail>> ListAgentDetailsAsync()
        {
            return await _dpAgentDal.GetAgentDetails();
        }

        public async Task DeleteAgentAsync(Agent agent)
        {
            await _dpAgentDal.DeleteAsync(agent);
        }
    }
}