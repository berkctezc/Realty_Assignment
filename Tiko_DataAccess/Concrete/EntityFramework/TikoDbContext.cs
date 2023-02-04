namespace Tiko_DataAccess.Concrete.EntityFramework;

public class TikoDbContext : DbContext
{
    public TikoDbContext(DbContextOptions<TikoDbContext> options) : base(options)
    {
    }

    public TikoDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=..\\Tiko_WebAPI\\Data\\tiko.db",
            b => b.MigrationsAssembly("Tiko_WebAPI"));
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<House> Houses { get; set; }
}