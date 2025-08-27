using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Queries.CarQueries;
using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Application.Interfaces;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithRelationsByIdQueryHandler(ICarRepository repository,
                                            IMapper mapper)
    {
        public async Task<GetCarWithAllQueryResult> Handle(GetCarByIdQuery query)
        {
            var entity = await repository.GetCarWithRelationsById(query.Id);
            return mapper.Map<GetCarWithAllQueryResult>(entity);
        }
    }
}
