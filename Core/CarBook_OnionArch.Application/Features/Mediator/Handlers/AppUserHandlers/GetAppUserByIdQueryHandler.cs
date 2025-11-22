using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    internal class GetAppUserByIdQueryHandler(IRepository<AppUser> repository,
                                        IMapper mapper)
        : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
    {
        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetAppUserByIdQueryResult>(entity);
        }
    }
}