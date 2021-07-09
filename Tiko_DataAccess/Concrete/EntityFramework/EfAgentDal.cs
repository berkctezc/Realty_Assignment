using Tiko_DataAccess.Abstract;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class EfAgentDal : GenericRepositoryEf<Agent, TikoDbContext>, IAgentDal { }
}