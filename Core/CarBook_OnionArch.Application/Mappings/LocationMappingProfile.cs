using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.LocationCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.LocationResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    internal class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Location, CreateLocationCommand>().ReverseMap();
            CreateMap<Location, UpdateLocationCommand>().ReverseMap();
            CreateMap<Location, GetLocationByIdQueryResult>();
            CreateMap<Location, GetLocationQueryResult>();
        }
    }
}
