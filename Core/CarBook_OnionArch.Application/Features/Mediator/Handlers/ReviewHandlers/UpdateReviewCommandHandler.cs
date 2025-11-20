using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler(IRepository<Review> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        IValidator<UpdateReviewCommand> validator)
        : IRequestHandler<UpdateReviewCommand, bool>
    {
        public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var validationResul = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResul.IsValid)
            {
                throw new ValidationException(validationResul.Errors);
            }

            var entity = mapper.Map<Review>(request);
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