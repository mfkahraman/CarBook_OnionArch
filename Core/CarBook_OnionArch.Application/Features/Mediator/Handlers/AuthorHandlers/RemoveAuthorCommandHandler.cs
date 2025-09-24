using CarBook_OnionArch.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AuthorHandlers
{
    internal class RemoveAuthorCommandHandler(IRepository<Author> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveAuthorCommand, bool>
    {
        public async Task<bool> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
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