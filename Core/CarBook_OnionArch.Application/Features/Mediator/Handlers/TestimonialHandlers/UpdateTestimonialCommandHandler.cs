using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler(IRepository<Testimonial> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateTestimonialCommand, bool>
    {
        public async Task<bool> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Testimonial>(request);
            repository.Update(entity);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Db güncelleme işlemi sırasında bir sorun oluştu.");
            }
            return true;
        }
    }
}