using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.TestimonialResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler(IRepository<Testimonial> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateTestimonialCommand, GetTestimonialByIdQueryResult>
    {
        public async Task<GetTestimonialByIdQueryResult> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Testimonial>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetTestimonialByIdQueryResult>(entity);
        }
    }
}