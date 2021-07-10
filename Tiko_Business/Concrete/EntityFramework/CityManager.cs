using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Common;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Concrete.EntityFramework
{
    public class CityManager : ICityService
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