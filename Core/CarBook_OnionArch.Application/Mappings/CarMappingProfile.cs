using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.CarCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<Car,CreateCarCommand>().ReverseMap();
            CreateMap<Car,UpdateCarCommand>().ReverseMap();
            CreateMap<Car, GetCarQueryResult>();
            CreateMap<Car, GetCarByIdQueryResult>();
            CreateMap<Car, GetCarWithBrandQueryResult>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
        }
    }
}
