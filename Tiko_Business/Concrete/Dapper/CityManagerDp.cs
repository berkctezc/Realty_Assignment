using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Concrete.Dapper
{
    public class CityManagerDp : ICityServiceDp
    {
        private readonly ICityDalDp _cityDalDp;

        public CityManagerDp(ICityDalDp cityDalDp)
        {
            _cityDalDp = cityDalDp;
        }

        public async Task CreateCityAsync(City city)
        {
            await _cityDalDp.CreateAsync(city);
        }

        public async Task<List<City>> ListCitiesAsync()
        {
            return await _cityDalDp.GetAllAsync();
        }
    }
}