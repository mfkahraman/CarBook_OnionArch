using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.ServiceResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Service, CreateServiceCommand>().ReverseMap();
            CreateMap<Service, UpdateServiceCommand>().ReverseMap();
            CreateMap<Service, GetServiceByIdQueryResult>();
            CreateMap<Service, GetServiceQueryResult>();
        }
    }
}
