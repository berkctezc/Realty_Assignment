using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiko_DataAccess.Abstract;
using Tiko_WebAPI.Data;

namespace Tiko_DataAccess.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly TikoDbContext context = new();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }


        public async Task CreateAsync(T x)
        {
            var createdEntity = context.Entry(x);
            createdEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await _object.ToListAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter)
        {
            return await _object.Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _object.SingleOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(T x)
        {
            var updatedEntity = context.Entry(x);
            updatedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T x)
        {
            var deletedEntity = context.Entry(x);
            deletedEntity.State = EntityState.Deleted;
            _object.Remove(x);
            await context.SaveChangesAsync();
        }
    }
}
