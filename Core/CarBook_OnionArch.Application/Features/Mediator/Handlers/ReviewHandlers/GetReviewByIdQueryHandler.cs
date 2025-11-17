using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByIdQueryHandler(IRepository<Review> repository,
                                        IMapper mapper)
        : IRequestHandler<GetReviewByIdQuery, GetReviewByIdQueryResult>
    {
        public async Task<GetReviewByIdQueryResult> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetReviewByIdQueryResult>(entity);
        }
    }
}