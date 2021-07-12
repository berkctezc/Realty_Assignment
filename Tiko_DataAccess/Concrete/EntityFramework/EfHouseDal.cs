using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class EfHouseDal : EfGenericRepository<House, TikoDbContext>, IEfHouseDal
    {
        public async Task UpdateHousePriceAsync(House house, int newPrice)
        {
            await using TikoDbContext context = new();
            var houseToUpdate = await context.Houses.SingleAsync(x => x.Id == house.Id);
            houseToUpdate.Price = newPrice;
            await context.SaveChangesAsync();
        }

        public async Task<List<HouseDetail>> GetHouseDetails(Expression<Func<House, bool>> filter = null)
        {
            await using TikoDbContext context = new();
            var result =
                from house in filter == null ? context.Houses : context.Houses.Where(filter)
                join city in context.Cities on house.CityId equals city.Id
                join agent in context.Agents on house.AgentId equals agent.Id
                select new HouseDetail()
                {
                    Id = house.Id,
                    Price = house.Price,
                    Address = house.Address,
                    Description = house.Description,
                    BedroomCount = house.BedroomCount,
                    CityName = city.Name,
                    AgentName = agent.Name
                };
            return result.ToList();
        }
    }
}