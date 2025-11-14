using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.RentalQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.RentalResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.RentalHandlers
{
    public class GetRentalByIdQueryHandler(IRepository<Rental> repository,
                                        IMapper mapper)
        : IRequestHandler<GetRentalByIdQuery, GetRentalByIdQueryResult>
    {
        public async Task<GetRentalByIdQueryResult> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetRentalByIdQueryResult>(entity);
        }
    }
}