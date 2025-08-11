using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.BlogCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    internal class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogByIdQueryResult>();
            CreateMap<Blog, GetBlogsQueryResult>();
        }
    }
}
