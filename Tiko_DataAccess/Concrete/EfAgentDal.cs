using Tiko_DataAccess.Abstract;
using Tiko_Entities.Concrete;
using Tiko_WebAPI.Data;

namespace Tiko_DataAccess.Concrete
{
    public class EfAgentDal : GenericRepositoryEf<Agent,TikoDbContext>, IAgentDal { }
}
