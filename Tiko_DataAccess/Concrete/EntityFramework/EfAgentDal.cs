using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class EfAgentDal : GenericRepositoryEf<Agent, TikoDbContext>, IAgentDal
    {
        public async Task<List<AgentDetail>> GetAgentDetails()
        {
            await using TikoDbContext context = new();
            var result = from agent in context.Agents
                         join city in context.Cities on agent.CityId equals city.Id
                         select new AgentDetail()
                         {
                             Id = agent.Id,
                             Name = agent.Name,
                             CityName = city.Name
                         };
            return result.ToList();
        }
    }
}