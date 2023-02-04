namespace Tiko_Business.Concrete.EntityFramework;

public class EfCityManager : IEfCityService
{
    private readonly IEfCityDal _efCityDal;

    public EfCityManager(IEfCityDal efCityDal)
        => _efCityDal = efCityDal;

    public async Task CreateCityAsync(City city)
        => await _efCityDal.CreateAsync(city);

    public async Task<List<City>> ListCitiesAsync()
        => await _efCityDal.GetAllAsync();
}