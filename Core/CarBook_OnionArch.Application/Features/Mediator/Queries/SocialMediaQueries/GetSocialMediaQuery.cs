using CarBook_OnionArch.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public record GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>;
}
