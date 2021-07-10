using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Tiko_Business.Abstract.Dapper;
using Tiko_Business.Abstract.EntityFramework;
using Tiko_Business.Concrete.Dapper;
using Tiko_Business.Concrete.EntityFramework;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_DataAccess.Concrete.Dapper;
using Tiko_DataAccess.Concrete.EntityFramework;

namespace Tiko_WebAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<TikoDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tiko_WebAPI", Version = "v1" });
            });

            // ENTITY FRAMEWORK
            services.AddScoped<IAgentServiceEf, AgentManager>();
            services.AddScoped<IAgentDal, EfAgentDal>();

            services.AddScoped<ICityServiceEf, CityManager>();
            services.AddScoped<ICityDal, EfCityDal>();

            services.AddScoped<IHouseServiceEf, HouseManager>();
            services.AddScoped<IHouseDal, EfHouseDal>();

            // DAPPER
            services.AddScoped<IAgentServiceDp, AgentManagerDp>();
            services.AddScoped<IAgentDalDp, DpAgentDal>();

            services.AddScoped<ICityServiceDp, CityManagerDp>();
            services.AddScoped<ICityDalDp, DpCityDal>();

            services.AddScoped<IHouseServiceDp, HouseManagerDp>();
            services.AddScoped<IHouseDalDp, DpHouseDal>();

            return services;
        }
    }
}