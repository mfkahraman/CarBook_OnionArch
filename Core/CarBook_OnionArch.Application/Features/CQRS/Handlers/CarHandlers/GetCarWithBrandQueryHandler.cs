using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Application.Interfaces;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler(ICarRepository repository,
                                            IMapper mapper)
    {
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await repository.GetCarsWithBrandsAsync();
            return mapper.Map<List<GetCarWithBrandQueryResult>>(values);
        }
    }
}
