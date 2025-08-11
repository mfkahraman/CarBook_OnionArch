using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, GetCommentByIdQueryResult>();
            CreateMap<Comment, GetCommentsQueryResult>();
        }
    }
}
