using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries
{
    public record GetAppUserByIdQuery(int Id) : IRequest<GetAppUserByIdQueryResult>;
}
