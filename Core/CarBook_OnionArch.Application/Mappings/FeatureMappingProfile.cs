using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class FeatureMappingProfile : Profile
    {
        public FeatureMappingProfile()
        {
            CreateMap<Feature, CreateFeatureCommand>().ReverseMap();
            CreateMap<Feature, UpdateFeatureCommand>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdQueryResult>();
            CreateMap<Feature, GetFeatureQueryResult>();
        }
    }
}
