using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract.Dapper
{
    public interface IHouseServiceDp
    {
        Task CreateHouseAsync(House house);

        Task<House> GetHouseByIdAsync(int id);

        List<House> ListHousesByAgentId(int id);

        List<House> ListHousesByCityId(int id);

        Task UpdateHousePriceAsync(int houseId, int newPrice);

        Task DeleteHouseAsync(House house);
    }
}