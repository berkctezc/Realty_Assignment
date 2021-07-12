using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_Business.Concrete.EntityFramework
{
    public class EfHouseManager : IEfHouseService
    {
        private readonly IEfHouseDal _efHouseDal;

        public EfHouseManager(IEfHouseDal efHouseDal)
        {
            _efHouseDal = efHouseDal;
        }

        public async Task CreateHouseAsync(House house)
        {
            await _efHouseDal.CreateAsync(house);
        }

        public async Task<House> GetHouseByIdAsync(int id)
        {
            return await _efHouseDal.GetAsync(h => h.Id == id);
        }

        public async Task<List<House>> ListHousesByAgentIdAsync(int id)
        {
            return await _efHouseDal.GetListAsync(x => x.AgentId == id);
        }

        public async Task<List<HouseDetail>> ListHouseDetailsByAgentIdAsync(int id)
        {
            return await _efHouseDal.GetHouseDetails(x=>x.AgentId==id);
        }

        public async Task<List<House>> ListHousesByCityIdAsync(int id)
        {
            return await _efHouseDal.GetListAsync(x => x.CityId == id);
        }

        public async Task<List<HouseDetail>> ListHouseDetailsByCityIdAsync(int id)
        {
            return await _efHouseDal.GetHouseDetails(x => x.CityId == id);
        }

        public async Task UpdateHousePriceAsync(House house, int newPrice)
        {
            await _efHouseDal.UpdateHousePriceAsync(house, newPrice);
        }

        public async Task DeleteHouseAsync(House house)
        {
            await _efHouseDal.DeleteAsync(house);
        }
    }
}