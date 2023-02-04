namespace Tiko_DataAccess.Abstract.Dapper;

public interface IDpAgentDal : IDpRepository<Agent>
{
    Task<List<AgentDetail>> GetAgentDetails();
}