using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewComandHandler(IRepository<Review> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateReviewCommand, GetReviewByIdQueryResult>
    {
        public async Task<GetReviewByIdQueryResult> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
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