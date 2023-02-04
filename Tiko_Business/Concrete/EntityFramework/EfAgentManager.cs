namespace Tiko_Business.Concrete.EntityFramework;

public class EfAgentManager : IEfAgentService
{
    private readonly IEfAgentDal _efAgentDal;

    public EfAgentManager(IEfAgentDal efAgentDal)
    {
        _efAgentDal = efAgentDal;
    }

    public async Task CreateAgentAsync(Agent agent)
    {
        await _efAgentDal.CreateAsync(agent);
    }

    public async Task<Agent> GetAgentByIdAsync(int id)
    {
        return await _efAgentDal.GetAsync(a => a.Id == id);
    }

    public async Task<List<Agent>> ListAgentsAsync()
    {
        return await _efAgentDal.GetAllAsync();
    }

    public async Task<List<AgentDetail>> ListAgentDetailsAsync()
    {
        return await _efAgentDal.GetAgentDetails();
    }

    public async Task DeleteAgentAsync(Agent agent)
    {
        await _efAgentDal.DeleteAsync(agent);
    }
}