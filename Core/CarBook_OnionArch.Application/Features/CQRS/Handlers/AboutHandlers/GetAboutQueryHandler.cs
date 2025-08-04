using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.AboutResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler(IRepository<About> repository,
                                        IMapper mapper)
    {
        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<GetAboutQueryResult>>(values);
        }
    }
}
