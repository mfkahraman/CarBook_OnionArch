using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.ServiceResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler(IRepository<Service> repository,
                                        IMapper mapper)
        : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetServiceByIdQueryResult>(entity);
        }
    }
}