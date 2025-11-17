using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewsListQueryHandler(IRepository<Review> repository,
                                        IMapper mapper)
        : IRequestHandler<GetReviewsListQuery, List<GetReviewsListQueryResult>>
    {
        public async Task<List<GetReviewsListQueryResult>> Handle(GetReviewsListQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetReviewsListQueryResult>>(values);
        }
    }
}