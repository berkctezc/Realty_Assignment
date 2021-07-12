using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Abstract;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<TEntity, TContext> : IEfRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()

    {
        public async Task CreateAsync(TEntity x)
        {
            await using TContext context = new();
            var createdEntity = context.Entry(x);
            createdEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            await using TContext context = new();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using TContext context = new();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using TContext context = new();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(TEntity x)
        {
            await using TContext context = new();
            var updatedEntity = context.Entry(x);
            updatedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity x)
        {
            await using TContext context = new();
            var deletedEntity = context.Entry(x);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}