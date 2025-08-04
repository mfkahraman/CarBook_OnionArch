using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.BannerCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.BannerResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class BannerMappingProfile : Profile
    {
        public BannerMappingProfile()
        {
            CreateMap<Banner, CreateBannerCommand>().ReverseMap();
            CreateMap<Banner, UpdateBannerCommand>().ReverseMap();
            CreateMap<Banner, GetBannerByIdQueryResult>();
            CreateMap<Banner, GetBannerQueryResult>();
        }
    }
}
