using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.AppRoleQueries
{
    public record GetAppRolesListQuery : IRequest<List<GetAppRolesListQueryResult>>;
}
