﻿namespace Tiko_DataAccess.Concrete.Dapper;

public class DpAgentDal : DpGenericRepository<Agent>, IDpAgentDal
{
    private readonly IDbConnection _db;

    public DpAgentDal(IConfiguration config) : base(config)
        => _db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));

    public async Task<List<AgentDetail>> GetAgentDetails()
    {
        const string sql = @"
            SELECT 
                Agents.Id,
                Agents.Name,
                Cities.Name as CityName
            FROM
                Agents
            INNER JOIN
                Cities ON Agents.CityId=Cities.Id;
            ";

        return (await _db.QueryAsync<AgentDetail>(sql)).ToList();
    }
}