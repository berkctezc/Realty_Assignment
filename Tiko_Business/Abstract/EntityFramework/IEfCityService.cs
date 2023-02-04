namespace Tiko_Business.Abstract.EntityFramework;

public interface IEfCityService
{
    Task CreateCityAsync(City city);

    Task<List<City>> ListCitiesAsync();
}