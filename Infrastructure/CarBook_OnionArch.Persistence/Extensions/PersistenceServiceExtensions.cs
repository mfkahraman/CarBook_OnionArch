using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Persistence.Context;
using CarBook_OnionArch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook_OnionArch.Persistence.Extensions
{
    public static class PersistenceServiceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext yapılandırması
            services.AddDbContext<CarBookContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            // Generic Repository injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Unit of Work and specific repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarRepository, CarRepository>();

            return services;
        }
    }
}
