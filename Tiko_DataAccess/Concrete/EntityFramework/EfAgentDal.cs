namespace Tiko_DataAccess.Concrete.EntityFramework;

public class EfAgentDal : EfGenericRepository<Agent, TikoDbContext>, IEfAgentDal
{
    public async Task<List<AgentDetail>> GetAgentDetailsAsync()
    {
        await using TikoDbContext context = new();

        var result = from agent in context.Agents
            join city in context.Cities on agent.CityId equals city.Id
            select new AgentDetail
            {
                Id = agent.Id,
                Name = agent.Name,
                CityName = city.Name
            };

        return await result.ToListAsync();
    }
}