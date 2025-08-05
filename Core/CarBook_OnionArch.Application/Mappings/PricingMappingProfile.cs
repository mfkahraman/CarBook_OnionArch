using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.PricingCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.PricingResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class PricingMappingProfile : Profile
    {
        public PricingMappingProfile()
        {
            CreateMap<Pricing, CreatePricingCommand>().ReverseMap();
            CreateMap<Pricing, UpdatePricingCommand>().ReverseMap();
            CreateMap<Pricing, GetPricingByIdQueryResult>();
            CreateMap<Pricing, GetPricingQueryResult>();
        }
    }
}
