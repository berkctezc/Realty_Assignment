namespace Tiko_DataAccess.Abstract.EntityFramework;

public interface IEfHouseDal : IEfRepository<House>
{
    Task UpdateHousePriceAsync(House house, int newPrice);

    Task<List<HouseDetail>> GetHouseDetailsAsync(Expression<Func<House, bool>> filter = null);
}