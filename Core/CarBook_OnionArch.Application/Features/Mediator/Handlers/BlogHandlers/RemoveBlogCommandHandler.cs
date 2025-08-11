using CarBook_OnionArch.Application.Features.Mediator.Commands.BlogCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler(IRepository<Blog> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveBlogCommand, bool>
    {
        public async Task<bool> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
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