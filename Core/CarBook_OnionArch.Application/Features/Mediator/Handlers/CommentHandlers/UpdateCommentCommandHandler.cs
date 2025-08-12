using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CommentCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler(IRepository<Comment> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateCommentCommand, bool>
    {
        public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Comment>(request);
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
