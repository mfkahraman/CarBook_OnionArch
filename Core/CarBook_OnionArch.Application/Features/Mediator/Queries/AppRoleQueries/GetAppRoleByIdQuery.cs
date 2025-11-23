using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.AppRoleQueries
{
    public record GetAppRoleByIdQuery(int id) : IRequest<GetAppRoleByIdQueryResult>;
}
