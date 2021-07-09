using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Abstract.EntityFramework
{
    public interface IHouseDal : IRepository<House>
    {
        Task UpdateHousePriceAsync(House house, int newPrice);
    }
}