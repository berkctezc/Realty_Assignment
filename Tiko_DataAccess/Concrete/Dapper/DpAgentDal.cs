using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_DataAccess.Concrete.Dapper
{
    public class DpAgentDal : GenericRepositoryDapper<Agent>, IAgentDalDp
    {
        private readonly IDbConnection _db;
        public DpAgentDal(IConfiguration config) : base(config)
        {
            this._db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<List<AgentDetail>> GetAgentDetails()
        {
            var sql = "SELECT Agents.Id,Agents.Name,Cities.Name as CityName FROM Agents INNER JOIN Cities ON Agents.CityId=Cities.Id;";

            return await Task.Run(() => _db.Query<AgentDetail>(sql).ToList());
        }
    }
}