using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.RentalQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.RentalResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.RentalHandlers
{
    public class GetAvailableCarsQueryHandler(ICarRepository repository, IMapper mapper)
        : IRequestHandler<GetAvailableCarsQuery, List<GetAvailableCarsQueryResult>>
    {
        public async Task<List<GetAvailableCarsQueryResult>> Handle(GetAvailableCarsQuery request, CancellationToken cancellationToken)
        {
            var availableCars = await repository.GetAvailableCarsAsync(request.startDate, request.endDate, cancellationToken);
            return mapper.Map<List<GetAvailableCarsQueryResult>>(availableCars);
        }
    }
}
