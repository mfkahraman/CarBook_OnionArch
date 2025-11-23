using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries
{
    public record AppUserSignInQuery(string UserName, string Password) : IRequest<string>;
}