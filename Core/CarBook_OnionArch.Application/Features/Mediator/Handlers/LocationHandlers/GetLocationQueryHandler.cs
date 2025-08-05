using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.LocationQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.LocationResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler(IRepository<Location> repository,
                                        IMapper mapper)
        : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetLocationQueryResult>>(values);
        }
    }
}