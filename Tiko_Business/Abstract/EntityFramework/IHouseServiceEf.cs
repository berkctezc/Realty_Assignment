using System.Collections.Generic;
using System.Threading.Tasks;
using Tiko_Business.Abstract.Common;
using Tiko_Entities.Concrete;

namespace Tiko_Business.Abstract.EntityFramework
{
    public interface IHouseServiceEf : IHouseService
    {
        Task<List<House>> ListHousesByAgentIdAsync(int id);

        Task<List<House>> ListHousesByCityIdAsync(int id);
    }
}