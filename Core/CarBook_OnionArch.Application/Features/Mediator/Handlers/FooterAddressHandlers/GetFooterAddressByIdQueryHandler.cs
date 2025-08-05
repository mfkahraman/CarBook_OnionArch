using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository,
                                        IMapper mapper)
        : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetFooterAddressByIdQueryResult>(entity);
        }
    }
}