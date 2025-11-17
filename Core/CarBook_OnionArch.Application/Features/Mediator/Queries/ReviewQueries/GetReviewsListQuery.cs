using CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.ReviewQueries
{
    public record GetReviewsListQuery : IRequest<List<GetReviewsListQueryResult>>;
}
