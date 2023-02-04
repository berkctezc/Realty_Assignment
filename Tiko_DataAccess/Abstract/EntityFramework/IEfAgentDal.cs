namespace Tiko_DataAccess.Abstract.EntityFramework;

public interface IEfAgentDal : IEfRepository<Agent>
{
    Task<List<AgentDetail>> GetAgentDetailsAsync();
}