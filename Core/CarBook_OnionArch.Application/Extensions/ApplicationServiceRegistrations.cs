using CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook_OnionArch.Application.Extensions
{
    public static class ApplicationServiceRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg=> { }, typeof(ApplicationServiceRegistrations).Assembly);

            //AboutHandlers
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();

            //BannerHandlers
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<GetBannerQueryHandler>();

            //BrandHandlers
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<GetBrandQueryHandler>();

            //Car Handlers
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();

            return services;
        }
    }
}
