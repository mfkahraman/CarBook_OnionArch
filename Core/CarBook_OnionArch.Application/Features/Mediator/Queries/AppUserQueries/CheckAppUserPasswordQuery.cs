using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries
{
    public record CheckAppUserPasswordQuery(int userId, string password) : IRequest<bool>;
}
