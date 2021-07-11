using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tiko_DataAccess.Abstract.Dapper
{
    public interface IDapperRepository<T>
        where T : class, new()
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T x);

        Task UpdateAsync(T x);

        Task DeleteAsync(T x);
    }
}