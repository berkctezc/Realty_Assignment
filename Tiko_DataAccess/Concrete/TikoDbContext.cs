using Microsoft.EntityFrameworkCore;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Data
{
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
            optionsBuilder.UseSqlite("Data Source=data\\tiko.db;");
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
