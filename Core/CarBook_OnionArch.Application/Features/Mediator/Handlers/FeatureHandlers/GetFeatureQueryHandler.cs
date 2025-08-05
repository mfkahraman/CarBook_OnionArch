using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler(IRepository<Feature> repository,
                                        IMapper mapper)
        : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var features = await repository.GetAllAsync();

            if (features == null || features.Count == 0)
            {
                throw new Exception("Dbde hiç feature bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetFeatureQueryResult>>(features);
        }
    }
}
