namespace Tiko_DataAccess.Concrete.Dapper;

public class DpGenericRepository<T> : IDpRepository<T> where T : class, IEntity, new()
{
    private readonly IDbConnection _db;

    protected DpGenericRepository(IConfiguration config)
        => _db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));

    public async Task<List<T>> GetAllAsync()
        => await _db.GetAllAsync<T>() as List<T>;

    public async Task<T> GetByIdAsync(int id)
        => await _db.GetAsync<T>(id);

    public async Task CreateAsync(T x)
        => await _db.InsertAsync(x);

    public async Task UpdateAsync(T x)
        => await _db.UpdateAsync(x);

    public async Task DeleteAsync(T x)
        => await _db.DeleteAsync(x);
}