using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler(IRepository<Review> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        IValidator<CreateReviewCommand> validator)
        : IRequestHandler<CreateReviewCommand, GetReviewByIdQueryResult>
    {
        public async Task<GetReviewByIdQueryResult> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var entity = mapper.Map<Review>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetReviewByIdQueryResult>(entity);
        }
    }
}