using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tiko_DataAccess.Abstract.EntityFramework
{
    public interface IEfRepository<T>
    {
        Task CreateAsync(T x);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task UpdateAsync(T x);

        Task DeleteAsync(T x);
    }
}