namespace Tiko_Business.Concrete.Dapper;

public class DpHouseManager : IDpHouseService
{
    private readonly IDpHouseDal _dpHouseDal;

    public DpHouseManager(IDpHouseDal dpHouseDal)
        => _dpHouseDal = dpHouseDal;

    public async Task CreateHouseAsync(House house)
        => await _dpHouseDal.CreateAsync(house);

    public async Task<House> GetHouseByIdAsync(int id)
        => await _dpHouseDal.GetByIdAsync(id);

    public Task<List<House>> ListHousesByAgentIdAsync(int id)
        => _dpHouseDal.GetHousesByAgentIdAsync(id);

    public async Task<List<HouseDetail>> ListHouseDetailsByAgentIdAsync(int id)
        => await _dpHouseDal.GetHouseDetails("agentId", id);

    public Task<List<House>> ListHousesByCityIdAsync(int id)
        => _dpHouseDal.GetHousesByCityIdAsync(id);

    public async Task<List<HouseDetail>> ListHouseDetailsByCityIdAsync(int id)
        => await _dpHouseDal.GetHouseDetails("cityId", id);

    public async Task UpdateHousePriceAsync(int houseId, int newPrice)
        => await _dpHouseDal.UpdateHousePriceAsync(houseId, newPrice);

    public async Task DeleteHouseAsync(House house)
        => await _dpHouseDal.DeleteAsync(house);
}