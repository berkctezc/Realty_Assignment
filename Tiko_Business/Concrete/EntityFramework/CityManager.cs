using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Concrete.EntityFramework
{
    public class CityManager : ICityServiceEf
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task CreateCityAsync(City city)
        {
            await _cityDal.CreateAsync(city);
        }

        public async Task<List<City>> ListCitiesAsync()
        {
            return await _cityDal.GetAllAsync();
        }
    }
}