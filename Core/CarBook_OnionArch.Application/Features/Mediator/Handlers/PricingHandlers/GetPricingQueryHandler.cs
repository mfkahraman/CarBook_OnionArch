using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.PricingQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.PricingResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler(IRepository<Pricing> repository,
                                        IMapper mapper)
        : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetPricingQueryResult>>(values);
        }
    }
}