using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {
    }
}
