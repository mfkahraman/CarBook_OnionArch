using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Persistence.Context;
using CarBook_OnionArch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarBook_OnionArch.Persistence.Extensions
{
    public static class PersistenceServiceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext yapılandırması
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });

            // Generic Repository injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Unit of Work and specific repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IImageService, ImageService>();

            return services;
        }
    }
}
