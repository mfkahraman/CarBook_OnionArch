using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, CreateAuthorCommand>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
            CreateMap<Author, GetAuthorByIdQueryResult>();
            CreateMap<Author, GetAuthorsQueryResult>();
        }
    }
}
