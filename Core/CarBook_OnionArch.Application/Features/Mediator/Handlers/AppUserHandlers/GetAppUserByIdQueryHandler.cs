using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    internal class GetAppUserByIdQueryHandler(IAppUserRepository repository,
                                            IMapper mapper)
        : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
    {
        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            AppUser? user =  await repository.FindUserByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return mapper.Map<GetAppUserByIdQueryResult>(user);
        }
    }
}