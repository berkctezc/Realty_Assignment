namespace Tiko_Business.Abstract.Dapper;

public interface IDpHouseService
{
    Task CreateHouseAsync(House house);

    Task<House> GetHouseByIdAsync(int id);

    Task<List<House>> ListHousesByAgentIdAsync(int id);

    Task<List<HouseDetail>> ListHouseDetailsByAgentIdAsync(int id);

    Task<List<House>> ListHousesByCityIdAsync(int id);

    Task<List<HouseDetail>> ListHouseDetailsByCityIdAsync(int id);

    Task UpdateHousePriceAsync(int houseId, int newPrice);

    Task DeleteHouseAsync(House house);
}