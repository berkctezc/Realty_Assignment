namespace Tiko_Business.Concrete.Dapper;

public class DpAgentManager : IDpAgentService
{
    private readonly IDpAgentDal _dpAgentDal;

    public DpAgentManager(IDpAgentDal dpAgentDal)
        => _dpAgentDal = dpAgentDal;

    public async Task CreateAgentAsync(Agent agent)
        => await _dpAgentDal.CreateAsync(agent);

    public async Task<Agent> GetAgentByIdAsync(int id)
        => await _dpAgentDal.GetByIdAsync(id);

    public async Task<List<Agent>> ListAgentsAsync()
        => await _dpAgentDal.GetAllAsync();

    public async Task<List<AgentDetail>> ListAgentDetailsAsync()
        => await _dpAgentDal.GetAgentDetails();

    public async Task DeleteAgentAsync(Agent agent)
        => await _dpAgentDal.DeleteAsync(agent);
}