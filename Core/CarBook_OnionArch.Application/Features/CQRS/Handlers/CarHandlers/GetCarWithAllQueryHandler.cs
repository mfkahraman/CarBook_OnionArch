using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Application.Interfaces;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithAllQueryHandler(ICarRepository repository,
                                           IMapper mapper)
    {
        public async Task<List<GetCarWithAllQueryResult>> Handle()
        {
            var cars = await repository.GetCarsWithAllAsync();
            var result = mapper.Map<List<GetCarWithAllQueryResult>>(cars);
            return result;
        }
    }
}
