﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tiko_DataAccess.Abstract;
using Tiko_Entities.Concrete;
using Tiko_WebAPI.Data;

namespace Tiko_DataAccess.Concrete
{
    public class EfHouseDal : GenericRepositoryEf<House, TikoDbContext>, IHouseDal
    {
        private readonly TikoDbContext _context;

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