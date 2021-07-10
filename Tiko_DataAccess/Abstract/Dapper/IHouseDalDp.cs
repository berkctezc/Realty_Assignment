using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Abstract.Dapper
{
    public interface IHouseDalDp : IDapperRepository<House>
    {
        List<House> GetHousesByAgentId(int agentId);

        List<House> GetHousesByCityId(int cityId);

        Task UpdateHousePriceAsync(int houseId, int newPrice);
    }
}