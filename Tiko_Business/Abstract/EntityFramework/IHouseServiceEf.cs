﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract.EntityFramework
{
    public interface IHouseServiceEf
    {
        Task CreateHouseAsync(House house);

        Task<List<House>> ListHousesByAgentIdAsync(int id);

        Task<List<House>> ListHousesByCityIdAsync(int id);

        Task UpdateHousePriceAsync(House house, int newPrice);

        Task DeleteHouseAsync(House house);
    }
}