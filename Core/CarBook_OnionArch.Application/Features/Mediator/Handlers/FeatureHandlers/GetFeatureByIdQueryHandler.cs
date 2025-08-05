using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler(IRepository<Feature> repository,
                                        IMapper mapper)
        : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var feature = await repository.GetByIdAsync(request.Id);
            if (feature == null)
            {
                throw new Exception("Dbde feature bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetFeatureByIdQueryResult>(feature);
        }
    }
}
