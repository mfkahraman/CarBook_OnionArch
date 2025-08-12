using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CommentCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler(IRepository<Comment> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateCommentCommand, GetCommentByIdQueryResult>
    {
        public async Task<GetCommentByIdQueryResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Comment>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetCommentByIdQueryResult>(entity);
        }
    }
}