namespace Tiko_DataAccess.Concrete.Dapper;

public class DpHouseDal : DpGenericRepository<House>, IDpHouseDal
{
    private readonly IDbConnection _db;

    public DpHouseDal(IConfiguration config) : base(config)
        => _db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));

    public async Task<List<House>> GetHousesByAgentIdAsync(int agentId)
    {
        const string sql = @"
            SELECT 
                * 
            FROM 
                Houses 
            WHERE 
                AgentId = @AgentId
            ";

        return (await _db.QueryAsync<House>(sql, new {AgentId = agentId})).ToList();
    }

    public async Task<List<House>> GetHousesByCityIdAsync(int cityId)
    {
        const string sql = "SELECT * from Houses WHERE CityId = @CityId";

        return (await _db.QueryAsync<House>(sql, new {CityId = cityId})).ToList();
    }

    public async Task<List<HouseDetail>> GetHouseDetails(string operationType, int id)
    {
        var sql = @$"
            SELECT 
                h.Id,
                h.Address,
                a.Name AS AgentName,
                h.BedroomCount,
                c.Name AS CityName,
                h.Description,
                h.Price 
            FROM 
                Houses AS h 
            INNER JOIN 
                Cities AS c ON h.CityId=c.Id 
            INNER JOIN 
                Agents AS a ON h.AgentId=a.Id 
            WHERE 
                h.{operationType}={id}
            ";

        return await Task.Run(() => _db.Query<HouseDetail>(sql).ToList());
    }

    public async Task UpdateHousePriceAsync(int houseId, int newPrice)
    {
        const string sql = "UPDATE Houses SET Price = @Price WHERE Id = @Id";

        await _db.ExecuteAsync(sql, new {Price = newPrice, Id = houseId});
    }
}