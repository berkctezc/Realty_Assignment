using System;
using System.Collections.Generic;
using System.Text;
using Tiko_DataAccess.Abstract;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete
{
    public class EfAgentDal : GenericRepositoryEf<Agent>, IAgentDal { }
    public class EfCityDal : GenericRepositoryEf<City>, ICityDal { }
    public class EfHouseDal : GenericRepositoryEf<House>, IHouseDal { }
}
