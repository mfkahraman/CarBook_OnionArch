using CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.ContactHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook_OnionArch.Application.Extensions
{
    public static class ApplicationServiceRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //AutoMapper Registration
            services.AddAutoMapper(cfg=> { }, typeof(ApplicationServiceRegistrations).Assembly);

            //MediatR Registration
            services.AddMediatR(cfg => 
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistrations).Assembly);
            });

            //About Handlers
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();

            //Banner Handlers
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<GetBannerQueryHandler>();

            //Brand Handlers
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

            //Category Handlers
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<GetCategoryQueryHandler>();

            //Contact Handlers
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<GetContactQueryHandler>();

            return services;
        }
    }
}
