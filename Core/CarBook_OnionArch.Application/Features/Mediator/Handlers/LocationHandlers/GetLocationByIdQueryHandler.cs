using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.LocationQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.LocationResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler(IRepository<Location> repository,
                                        IMapper mapper)
        : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetLocationByIdQueryResult>(entity);
        }
    }
}