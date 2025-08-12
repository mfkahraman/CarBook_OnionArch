using CarBook_OnionArch.Application.Features.Mediator.Commands.CommentCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class RemoveCommentCommandHandler(IRepository<Comment> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveCommentCommand, bool>
    {
        public async Task<bool> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
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