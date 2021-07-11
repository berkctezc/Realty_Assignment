using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_DataAccess.Abstract.EntityFramework
{
    public interface IHouseDal : IRepository<House>
    {
        Task UpdateHousePriceAsync(House house, int newPrice);

        Task<List<HouseDetail>> GetHouseDetails(Expression<Func<House, bool>> filter = null);
    }
}