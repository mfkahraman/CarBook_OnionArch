using CarBook_OnionArch.Application.Features.Mediator.Queries.AppRoleQueries;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppRoleHandlers
{
    public class IsAppRoleExistsQueryHandler(IAppRoleRepository repository)
        : IRequestHandler<IsAppRoleExistsQuery, bool>
    {
        public async Task<bool> Handle(IsAppRoleExistsQuery request, CancellationToken cancellationToken)
        {
            return await repository.IsRoleExistsAync(request.roleName);
        }
    }
}
