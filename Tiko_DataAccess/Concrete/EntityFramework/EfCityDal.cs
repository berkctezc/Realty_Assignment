using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : EfGenericRepository<City, TikoDbContext>, IEfCityDal { }
}