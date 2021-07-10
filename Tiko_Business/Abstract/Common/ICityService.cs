using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract.Common
{
    public interface ICityService
    {
        Task CreateCityAsync(City city);

        Task<List<City>> ListCitiesAsync();
    }
}