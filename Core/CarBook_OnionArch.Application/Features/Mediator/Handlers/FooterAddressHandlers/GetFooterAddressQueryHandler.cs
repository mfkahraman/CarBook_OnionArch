using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler(IRepository<FooterAddress> repository,
                                        IMapper mapper)
        : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetFooterAddressQueryResult>>(values);
        }
    }
}