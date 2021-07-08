using Microsoft.EntityFrameworkCore;
using Tiko_Entities.Concrete;

namespace Tiko_WebAPI.Data
{
    public class TikoDbContext : DbContext
    {
        public TikoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
