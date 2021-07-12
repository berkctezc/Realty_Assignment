using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Concrete.Dapper
{
    public class DpCityManager : IDpCityService
    {
        private readonly IDpCityDal _dpCityDal;

        public DpCityManager(IDpCityDal dpCityDal)
        {
            _dpCityDal = dpCityDal;
        }

        public async Task CreateCityAsync(City city)
        {
            await _dpCityDal.CreateAsync(city);
        }

        public async Task<List<City>> ListCitiesAsync()
        {
            return await _dpCityDal.GetAllAsync();
        }
    }
}