using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.AboutResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class AboutMappingProfile : Profile
    {
        public AboutMappingProfile()
        {
            CreateMap<About, GetAboutQueryResult>();
            CreateMap<About, GetAboutByIdQueryResult>();
        }
    }
}
