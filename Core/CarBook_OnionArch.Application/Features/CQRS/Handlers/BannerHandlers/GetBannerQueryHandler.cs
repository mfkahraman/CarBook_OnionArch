using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.BannerResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler(IRepository<Banner> repository,
                                        IMapper mapper)
    {
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<GetBannerQueryResult>>(values);
        }
    }
}
