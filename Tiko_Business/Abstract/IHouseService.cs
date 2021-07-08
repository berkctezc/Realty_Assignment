using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract
{
    public interface IHouseService
    {
        Task CreateHouseAsync(House house);
        Task<List<House>> ListHousesByAgentIdAsync(int id);
        Task<List<House>> ListHousesByCityIdAsync(int id);
        Task UpdateHousePriceAsync(House house);
        Task DeleteHouseAsync(House house);
    }
}