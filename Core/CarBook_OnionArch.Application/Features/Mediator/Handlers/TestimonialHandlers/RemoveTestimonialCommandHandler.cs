using CarBook_OnionArch.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler(IRepository<Testimonial> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveTestimonialCommand, bool>
    {
        public async Task<bool> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            await repository.RemoveAsync(request.Id);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Dbde silme işlemi sırasında bir sorun oluştu");
            }
            return true;
        }
    }
}