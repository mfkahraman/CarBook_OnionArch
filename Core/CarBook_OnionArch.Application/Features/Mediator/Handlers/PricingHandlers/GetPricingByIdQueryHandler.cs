using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.PricingQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.PricingResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler(IRepository<Pricing> repository,
                                        IMapper mapper)
        : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetPricingByIdQueryResult>(entity);
        }
    }
}