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
            CreateMap<Blog, GetBlogsWithDetailsQueryResult>();
            //    .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.Id))
            //    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            //    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
            //    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
        }
    }
}
