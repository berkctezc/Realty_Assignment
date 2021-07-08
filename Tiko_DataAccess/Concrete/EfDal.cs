using System;
using System.Collections.Generic;
using System.Text;
using Tiko_DataAccess.Abstract;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete
{
    public class EfAgentDal : GenericRepository<Agent>, IAgentDal { }
    public class EfCityDal : GenericRepository<City>, ICityDal { }
    public class EfHouseDal : GenericRepository<House>, IHouseDal { }
}
