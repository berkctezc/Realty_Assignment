using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class EfHouseDal : GenericRepositoryEf<House, TikoDbContext>, IHouseDal
    {
        public async Task UpdateHousePriceAsync(House house, int newPrice)
        {
            await using TikoDbContext context = new();
            House houseToUpdate = await context.Houses.SingleAsync(x => x.Id == house.Id);
            houseToUpdate.Price = newPrice;
            await context.SaveChangesAsync();
        }
    }
}