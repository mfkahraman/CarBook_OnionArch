using CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CheckPasswordQueryHandler(IAppUserRepository repository)
        : IRequestHandler<CheckAppUserPasswordQuery, bool>
    {
        public async Task<bool> Handle(CheckAppUserPasswordQuery request, CancellationToken cancellationToken)
        {
            return await repository.CheckPasswordAsync(request.userId, request.password);
        }
    }
}
