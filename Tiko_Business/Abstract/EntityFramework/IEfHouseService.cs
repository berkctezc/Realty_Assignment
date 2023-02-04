namespace Tiko_Business.Abstract.EntityFramework;

public interface IEfHouseService
{
    Task CreateHouseAsync(House house);

    Task<House> GetHouseByIdAsync(int id);

    Task<List<House>> ListHousesByAgentIdAsync(int id);

    Task<List<HouseDetail>> ListHouseDetailsByAgentIdAsync(int id);

    Task<List<House>> ListHousesByCityIdAsync(int id);

    Task<List<HouseDetail>> ListHouseDetailsByCityIdAsync(int id);

    Task UpdateHousePriceAsync(House house, int newPrice);

    Task DeleteHouseAsync(House house);
}