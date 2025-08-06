using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.TestimonialResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler(IRepository<Testimonial> repository,
                                        IMapper mapper)
        : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetTestimonialQueryResult>>(values);
        }
    }
}