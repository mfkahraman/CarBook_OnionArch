using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppRoleQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppRoleHandlers
{
    public class GetAppRoleByIdQueryHandler(IAppRoleRepository repository,
                                            IMapper mapper)
        : IRequestHandler<GetAppRoleByIdQuery, GetAppRoleByIdQueryResult>
    {
        public async Task<GetAppRoleByIdQueryResult> Handle(GetAppRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetAppRoleById(request.id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetAppRoleByIdQueryResult>(entity);
        }
    }
}