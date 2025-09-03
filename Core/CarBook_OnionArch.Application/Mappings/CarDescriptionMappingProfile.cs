using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class CarDescriptionMappingProfile : Profile
    {
        public CarDescriptionMappingProfile()
        {
            CreateMap<CarDescription, GetCarDescriptionQueryResult>().ReverseMap();
            CreateMap<CarDescription, CreateCarDescriptionCommand>().ReverseMap();
            CreateMap<CarDescription, UpdateCarDescriptionCommand>().ReverseMap();
        }
    }
}