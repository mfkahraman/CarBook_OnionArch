using CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class RemoveReviewComandHandler(IRepository<Review> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveReviewCommand, bool>
    {
        public async Task<bool> Handle(RemoveReviewCommand request, CancellationToken cancellationToken)
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