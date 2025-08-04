using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Queries.AboutQueries;
using CarBook_OnionArch.Application.Features.CQRS.Results.AboutResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler(IRepository<About> repository,
                                           IMapper mapper)
    {
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var about = await repository.GetByIdAsync(query.id);
            return mapper.Map<GetAboutByIdQueryResult>(about);
        }
    }
}
