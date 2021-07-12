using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_Business.Concrete.Dapper
{
    public class HouseManagerDp : IHouseServiceDp
    {
        private readonly IHouseDalDp _houseDalDp;

        public HouseManagerDp(IHouseDalDp houseDalDp)
        {
            _houseDalDp = houseDalDp;
        }

        public async Task CreateHouseAsync(House house)
        {
            await _houseDalDp.CreateAsync(house);
        }

        public async Task<House> GetHouseByIdAsync(int id)
        {
            return await _houseDalDp.GetByIdAsync(id);
        }

        public Task<List<House>> ListHousesByAgentIdAsync(int id)
        {
            return _houseDalDp.GetHousesByAgentIdAsync(id);
        }

        public async Task<List<HouseDetail>> ListHouseDetailsByAgentIdAsync(int id)
        {
            return await _houseDalDp.GetHouseDetails("agentId", id);
        }

        public Task<List<House>> ListHousesByCityIdAsync(int id)
        {
            return _houseDalDp.GetHousesByCityIdAsync(id);
        }

        public async Task<List<HouseDetail>> ListHouseDetailsByCityIdAsync(int id)
        {
            return await _houseDalDp.GetHouseDetails("cityId", id);
        }

        public async Task UpdateHousePriceAsync(int houseId, int newPrice)
        {
            await _houseDalDp.UpdateHousePriceAsync(houseId, newPrice);
        }

        public async Task DeleteHouseAsync(House house)
        {
            await _houseDalDp.DeleteAsync(house);
        }
    }
}