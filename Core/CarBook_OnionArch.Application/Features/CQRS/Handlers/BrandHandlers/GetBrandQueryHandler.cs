using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.BrandResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler(IRepository<Brand> repository,
                                            IMapper mapper)
    {
        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<GetBrandQueryResult>>(values);
        }
    }
}
