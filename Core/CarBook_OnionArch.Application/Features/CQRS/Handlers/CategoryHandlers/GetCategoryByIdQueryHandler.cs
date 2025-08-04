using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook_OnionArch.Application.Features.CQRS.Results.CategoryResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> repository,
                                            IMapper mapper)
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var entity = await repository.GetByIdAsync(query.Id);
            return mapper.Map<GetCategoryByIdQueryResult>(entity);
        }
    }
}
