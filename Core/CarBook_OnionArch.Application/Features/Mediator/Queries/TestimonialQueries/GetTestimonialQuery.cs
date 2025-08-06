using CarBook_OnionArch.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.TestimonialQueries
{
    public record GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>;
}
