using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiko_DataAccess.Abstract;
using Tiko_Entities.Concrete;
using Tiko_WebAPI.Data;

namespace Tiko_DataAccess.Concrete
{
    public class EfAgentDal : GenericRepositoryEf<Agent>, IAgentDal { }
    public class EfCityDal : GenericRepositoryEf<City>, ICityDal { }
    public class EfHouseDal : GenericRepositoryEf<House>, IHouseDal
    {
        private readonly TikoDbContext _context = new();

        public EfHouseDal(TikoDbContext context)
        {
            _context = context;
        }

        public async Task UpdateHousePriceAsync(House house, int newPrice)
        {
            House houseToUpdate = await _context.Houses.SingleAsync(x => x.Id == house.Id);
            houseToUpdate.Price = newPrice;
            await _context.SaveChangesAsync();
        }
    }
}
