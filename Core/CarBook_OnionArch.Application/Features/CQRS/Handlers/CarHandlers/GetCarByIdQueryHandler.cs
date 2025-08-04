using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Queries.CarQueries;
using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler(IRepository<Car> repository,
                                            IMapper mapper)
    {
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var entity = await repository.GetByIdAsync(query.Id);
            return mapper.Map<GetCarByIdQueryResult>(entity);
        }
    }
}
