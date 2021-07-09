using Tiko_DataAccess.Abstract;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : GenericRepositoryEf<City, TikoDbContext>, ICityDal { }
}