namespace Tiko_Business.Abstract.Dapper;

public interface IDpCityService
{
    Task CreateCityAsync(City city);

    Task<List<City>> ListCitiesAsync();
}