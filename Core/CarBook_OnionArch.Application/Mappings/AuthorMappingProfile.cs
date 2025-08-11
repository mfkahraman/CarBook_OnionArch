using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, GetAuthorByIdQueryResult>();
            CreateMap<Author, GetAuthorsQueryResult>();
        }
    }
}
