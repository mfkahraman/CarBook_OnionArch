using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUsersListQueryHandler(IRepository<AppUser> repository,
                                        IMapper mapper)
        : IRequestHandler<GetAppUsersListQuery, List<GetAppUsersListQueryResult>>
    {
        public async Task<List<GetAppUsersListQueryResult>> Handle(GetAppUsersListQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetAppUsersListQueryResult>>(values);
        }
    }
}