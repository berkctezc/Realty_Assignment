using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Concrete.EntityFramework
{
    public class HouseManager : IHouseServiceEf
    {
        private readonly IHouseDal _houseDal;

        public HouseManager(IHouseDal houseDal)
        {
            _houseDal = houseDal;
        }

        public async Task CreateHouseAsync(House house)
        {
            await _houseDal.CreateAsync(house);
        }

        public async Task<House> GetHouseByIdAsync(int id)
        {
            return await _houseDal.GetAsync(h => h.Id == id);
        }

        public async Task<List<House>> ListHousesByAgentIdAsync(int id)
        {
            return await _houseDal.GetListAsync(x => x.AgentId == id);
        }

        public async Task<List<House>> ListHousesByCityIdAsync(int id)
        {
            return await _houseDal.GetListAsync(x => x.CityId == id);
        }

        public async Task UpdateHousePriceAsync(House house, int newPrice)
        {
            await _houseDal.UpdateHousePriceAsync(house, newPrice);
        }

        public async Task DeleteHouseAsync(House house)
        {
            await _houseDal.DeleteAsync(house);
        }
    }
}