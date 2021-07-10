using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Abstract;

namespace Tiko_DataAccess.Concrete.Dapper
{
    public class GenericRepositoryDapper<T> : IDapperRepository<T> where T : class,IEntity, new()
    {
        private readonly IDbConnection _db;

        public GenericRepositoryDapper(IConfiguration config)
        {
            this._db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.GetAllAsync<T>() as List<T>;
        }

        public async Task<T> GetById(int id)
        {
            return await _db.GetAsync<T>(id);
        }

        public async Task CreateAsync(T x)
        {
            await _db.InsertAsync(x);
        }

        public async Task UpdateAsync(T x)
        {
            await _db.UpdateAsync(x);
        }

        public async Task DeleteAsync(T x)
        {
            await _db.DeleteAsync(x);
        }
    }
}