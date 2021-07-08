using Tiko_DataAccess.Abstract;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete
{
    public class EfCityDal : GenericRepositoryEf<City>, ICityDal { }
}