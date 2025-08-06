using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarPricingResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class CarPricingMappingProfile : Profile
    {
        public CarPricingMappingProfile()
        {
            CreateMap<CarPricing, GetCarPricingQueryResult>().ReverseMap();
        }
    }
}
