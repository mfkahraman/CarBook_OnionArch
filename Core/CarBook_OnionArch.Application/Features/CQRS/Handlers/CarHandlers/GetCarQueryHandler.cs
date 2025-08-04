using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler(IRepository<Car> repository,
                                            IMapper mapper)
    {
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<GetCarQueryResult>>(values);
        }
    }
}
