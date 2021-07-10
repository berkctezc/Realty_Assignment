using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Dapper;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;

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

        public List<House> ListHousesByAgentId(int id)
        {
            return _houseDalDp.GetHousesByAgentId(id);
        }

        public List<House> ListHousesByCityId(int id)
        {
            return _houseDalDp.GetHousesByCityId(id);
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