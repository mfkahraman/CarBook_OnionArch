using CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook_OnionArch.Application.Extensions
{
    public static class ApplicationServiceRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg=> { }, typeof(ApplicationServiceRegistrations).Assembly);

            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();

            return services;
        }
    }
}
