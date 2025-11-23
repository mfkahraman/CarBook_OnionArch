using CarBook_OnionArch.Application.Features.Mediator.Results.AppUserResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries
{
    public record GetAppUserByUserNameQuery(string userName) : IRequest<GetAppUserByUserNameQueryResult>;
}
