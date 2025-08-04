using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.CategoryResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler(IRepository<Category> repository,
                                            IMapper mapper)
    {
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<GetCategoryQueryResult>>(values);

        }
    }
}