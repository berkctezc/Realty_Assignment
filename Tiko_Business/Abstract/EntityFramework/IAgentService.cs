namespace Tiko_Business.Abstract.EntityFramework;

public interface IEfAgentService
{
    Task CreateAgentAsync(Agent agent);

    Task<Agent> GetAgentByIdAsync(int id);

    Task<List<Agent>> ListAgentsAsync();

    Task<List<AgentDetail>> ListAgentDetailsAsync();

    Task DeleteAgentAsync(Agent agent);
}