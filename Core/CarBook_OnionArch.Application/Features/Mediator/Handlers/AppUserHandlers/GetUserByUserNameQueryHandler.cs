using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.AppUserResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetUserByUserNameQueryHandler(IAppUserRepository repository,
                                            IMapper mapper)
        : IRequestHandler<GetAppUserByUserNameQuery, GetAppUserByUserNameQueryResult>
    {
        public async Task<GetAppUserByUserNameQueryResult> Handle(GetAppUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            AppUser? user = await repository.FindUserByUserNameAsync(request.userName);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return mapper.Map<GetAppUserByUserNameQueryResult>(user);
        }
    }
}