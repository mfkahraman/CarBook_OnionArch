using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.AppRoleQueries
{
    public record IsAppRoleExistsQuery(string roleName) : IRequest<bool>;
}
