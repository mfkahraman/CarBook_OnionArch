using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<AppUser, CreateAppUserCommand>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserCommand>().ReverseMap();
            CreateMap<AppUser, GetAppUsersListQueryResult>();
            CreateMap<AppUser, GetAppUserByIdQueryResult>();
        }
    }
}
