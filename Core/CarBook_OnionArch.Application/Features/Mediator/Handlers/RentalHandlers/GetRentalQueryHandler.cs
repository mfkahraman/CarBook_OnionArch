using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.RentalQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.RentalResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.RentalHandlers
{
    public class GetRentalQueryHandler(IRepository<Rental> repository,
                                        IMapper mapper)
        : IRequestHandler<GetRentalQuery, List<GetRentalQueryResult>>
    {
        public async Task<List<GetRentalQueryResult>> Handle(GetRentalQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetRentalQueryResult>>(values);
        }
    }
}