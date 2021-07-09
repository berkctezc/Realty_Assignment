using Microsoft.Extensions.Configuration;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete.Dapper
{
    public class DpCityDal:GenericRepositoryDapper<City>,ICityDalDp
    {
        public DpCityDal(IConfiguration config) : base(config)
        {
        }
    }
}