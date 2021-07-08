using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract
{
    public interface ICityService
    {
        Task CreateCityAsync(City city);
        Task<List<City>> ListCitiesAsync();
    }
}