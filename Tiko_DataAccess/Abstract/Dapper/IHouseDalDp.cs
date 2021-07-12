using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_DataAccess.Abstract.Dapper
{
    public interface IHouseDalDp : IDapperRepository<House>
    {
        Task<List<House>> GetHousesByAgentIdAsync(int agentId);

        Task<List<House>> GetHousesByCityIdAsync(int cityId);

        Task<List<HouseDetail>> GetHouseDetails(string operationType,int id);

        Task UpdateHousePriceAsync(int houseId, int newPrice);
    }
}