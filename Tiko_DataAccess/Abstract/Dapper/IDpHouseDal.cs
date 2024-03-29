﻿namespace Tiko_DataAccess.Abstract.Dapper;

public interface IDpHouseDal : IDpRepository<House>
{
    Task<List<House>> GetHousesByAgentIdAsync(int agentId);

    Task<List<House>> GetHousesByCityIdAsync(int cityId);

    Task<List<HouseDetail>> GetHouseDetails(string operationType, int id);

    Task UpdateHousePriceAsync(int houseId, int newPrice);
}