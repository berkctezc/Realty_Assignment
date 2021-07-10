using Microsoft.Extensions.Configuration;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete.Dapper
{
    public class DpAgentDal : GenericRepositoryDapper<Agent>,IAgentDalDp
    {
        public DpAgentDal(IConfiguration config) : base(config)
        {
        }
    }
}
