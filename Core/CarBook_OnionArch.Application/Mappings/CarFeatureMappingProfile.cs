using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    internal class CarFeatureMappingProfile : Profile
    {
        public CarFeatureMappingProfile()
        {
            CreateMap<CarFeature, CreateCarFeatureCommand>().ReverseMap();
            CreateMap<CarFeature, UpdateCarFeatureCommand>().ReverseMap();
            CreateMap<CarFeature, GetCarFeatureQueryResult>();
        }
    }
}
