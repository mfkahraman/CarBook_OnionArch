using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, GetUserByIdQueryResult>();
        }
    }
}
