namespace Tiko_Business.Abstract.Dapper;

public interface IDpAgentService
{
    Task CreateAgentAsync(Agent agent);

    Task<Agent> GetAgentByIdAsync(int id);

    Task<List<Agent>> ListAgentsAsync();

    Task<List<AgentDetail>> ListAgentDetailsAsync();

    Task DeleteAgentAsync(Agent agent);
}