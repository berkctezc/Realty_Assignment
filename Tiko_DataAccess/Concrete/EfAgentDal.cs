using Tiko_DataAccess.Abstract;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete
{
    public class EfAgentDal : GenericRepositoryEf<Agent>, IAgentDal { }
}
