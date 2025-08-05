using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler(IRepository<SocialMedia> repository,
                                        IMapper mapper)
        : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetSocialMediaQueryResult>>(values);
        }
    }
}