using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Queries.BannerQueries;
using CarBook_OnionArch.Application.Features.CQRS.Results.BannerResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler(IRepository<Banner> repository,
                                            IMapper mapper)
    {
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var banner = await repository.GetByIdAsync(query.Id);
            return mapper.Map<GetBannerByIdQueryResult>(banner);
        }
    }
}
