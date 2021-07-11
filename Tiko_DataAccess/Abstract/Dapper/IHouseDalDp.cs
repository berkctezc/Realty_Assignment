using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Abstract.Dapper
{
    public interface IHouseDalDp : IDapperRepository<House>
    {
        Task<List<House>> GetHousesByAgentIdAsync(int agentId);

        Task<List<House>> GetHousesByCityIdAsync(int cityId);

        Task UpdateHousePriceAsync(int houseId, int newPrice);
    }
}