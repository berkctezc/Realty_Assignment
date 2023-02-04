namespace Tiko_Business.Concrete.EntityFramework;

public class EfAgentManager : IEfAgentService
{
    private readonly IEfAgentDal _efAgentDal;

    public EfAgentManager(IEfAgentDal efAgentDal)
        => _efAgentDal = efAgentDal;

    public async Task CreateAgentAsync(Agent agent)
        => await _efAgentDal.CreateAsync(agent);

    public async Task<Agent> GetAgentByIdAsync(int id)
        => await _efAgentDal.GetAsync(a => a.Id == id);

    public async Task<List<Agent>> ListAgentsAsync()
        => await _efAgentDal.GetAllAsync();

    public async Task<List<AgentDetail>> ListAgentDetailsAsync()
        => await _efAgentDal.GetAgentDetailsAsync();

    public async Task DeleteAgentAsync(Agent agent)
        => await _efAgentDal.DeleteAsync(agent);
}