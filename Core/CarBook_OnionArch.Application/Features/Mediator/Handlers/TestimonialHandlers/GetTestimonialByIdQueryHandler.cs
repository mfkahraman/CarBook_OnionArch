using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.TestimonialResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository,
                                        IMapper mapper)
        : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetTestimonialByIdQueryResult>(entity);
        }
    }
}