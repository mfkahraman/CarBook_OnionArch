using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository,
                                        IMapper mapper)
        : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetSocialMediaByIdQueryResult>(entity);
        }
    }
}