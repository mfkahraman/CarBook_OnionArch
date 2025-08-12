using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CommentCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
            CreateMap<Comment, GetCommentByIdQueryResult>();
            CreateMap<Comment, GetCommentsQueryResult>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author!.FullName))
                .ForMember(dest => dest.AuthorImageUrl, opt => opt.MapFrom(src => src.Author!.ImageUrl));
        }
    }
}
