using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AppRoleCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class AppRoleMappingProfile : Profile
    {
        public AppRoleMappingProfile()
        {
            CreateMap<AppRole, CreateAppRoleCommand>()
                .ForMember(dest => dest.roleName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
            CreateMap<AppRole, GetAppRolesListQueryResult>();
            CreateMap<AppRole, GetAppRoleByIdQueryResult>();
        }
    }
}
