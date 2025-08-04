using CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.BannerHandlers;
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

            return services;
        }
    }
}
