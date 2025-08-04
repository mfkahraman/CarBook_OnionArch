using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.BrandCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.BrandResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, GetBrandQueryResult>();
            CreateMap<Brand, GetBrandByIdQueryResult>();
        }
    }
}
