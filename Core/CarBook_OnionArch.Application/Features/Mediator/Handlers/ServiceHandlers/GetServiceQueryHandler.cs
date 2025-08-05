using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.ServiceResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler(IRepository<Service> repository,
                                        IMapper mapper)
        : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetServiceQueryResult>>(values);
        }
    }
}