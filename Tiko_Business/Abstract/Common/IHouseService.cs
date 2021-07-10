using System.Threading.Tasks;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract.Common
{
    public interface IHouseService
    {
        Task CreateHouseAsync(House house);

        Task UpdateHousePriceAsync(House house, int newPrice);

        Task DeleteHouseAsync(House house);
    }
}