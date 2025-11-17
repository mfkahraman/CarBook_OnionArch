using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    internal class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, CreateReviewCommand>().ReverseMap();
            CreateMap<Review, UpdateReviewCommand>().ReverseMap();
            CreateMap<Review, GetReviewByIdQueryResult>();
            CreateMap<Review, GetReviewsListQueryResult>();
            CreateMap<Review, GetReviewsListQueryResult>();
        }
    }
}
