using CarBook_OnionArch.Application.Features.Mediator.Results.RentalResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.RentalQueries
{
    public class GetRentalQuery : IRequest<List<GetRentalQueryResult>>;
}
