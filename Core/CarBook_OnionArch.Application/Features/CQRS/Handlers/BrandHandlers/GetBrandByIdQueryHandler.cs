using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Queries.BrandQueries;
using CarBook_OnionArch.Application.Features.CQRS.Results.BrandResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler(IRepository<Brand> repository,
                                            IMapper mapper)
    {
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var entity = await repository.GetByIdAsync(query.Id);
            return mapper.Map<GetBrandByIdQueryResult>(entity);
        }
    }
}
