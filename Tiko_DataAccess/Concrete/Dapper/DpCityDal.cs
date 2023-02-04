namespace Tiko_DataAccess.Concrete.Dapper;

public class DpCityDal : DpGenericRepository<City>, IDpCityDal
{
    public DpCityDal(IConfiguration config) : base(config)
    {
    }
}