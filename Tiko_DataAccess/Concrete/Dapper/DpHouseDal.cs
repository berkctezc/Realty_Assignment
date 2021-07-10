using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete.Dapper
{
    public class DpHouseDal : GenericRepositoryDapper<House>, IHouseDalDp
    {
        private IDbConnection db;
        public DpHouseDal(IConfiguration config) : base(config)
        {
            this.db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));
        }

        public List<House> GetHousesByAgentId(int agentId)
        {
            var sql = "SELECT * from Houses WHERE AgentId = @AgentId";
            return db.Query<House>(sql,new {@AgentId=agentId}).ToList();
        }

        public List<House> GetHousesByCityId(int cityId)
        {
            var sql = "SELECT * from Houses WHERE CityId = @CityId";
            return db.Query<House>(sql, new { @CityId = cityId }).ToList();
        }

        public async Task UpdateHousePriceAsync(int houseId, int newPrice)
        {
            var sql = "UPDATE Houses SET Price = @Price WHERE Id = @Id";
            await db.ExecuteAsync(sql,new {@Price=newPrice,@Id=houseId});
        }
    }
}