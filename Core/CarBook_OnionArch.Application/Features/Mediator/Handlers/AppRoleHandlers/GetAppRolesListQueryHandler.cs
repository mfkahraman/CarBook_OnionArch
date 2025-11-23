using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppRoleQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppRoleHandlers
{
    public class GetAppRolesListQueryHandler(IRepository<AppRole> repository,
                                            IMapper mapper)
        : IRequestHandler<GetAppRolesListQuery, List<GetAppRolesListQueryResult>>
    {
        public async Task<List<GetAppRolesListQueryResult>> Handle(GetAppRolesListQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetAppRolesListQueryResult>>(values);
        }
    }
}