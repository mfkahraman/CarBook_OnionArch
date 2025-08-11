using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Application.Interfaces;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsQueryHandler(ICarRepository repository,
                                           IMapper mapper)
    {
        public async Task<List<GetCarWithAllQueryResult>> Handle()
        {
            var cars = await repository.GetLast5CarsAsync();
            var result = mapper.Map<List<GetCarWithAllQueryResult>>(cars);
            return result;
        }
    }
}
