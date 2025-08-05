using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class SocialMediaMappingProfile : Profile
    {
        public SocialMediaMappingProfile()
        {
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaByIdQueryResult>();
            CreateMap<SocialMedia, GetSocialMediaQueryResult>();
        }
    }
}
