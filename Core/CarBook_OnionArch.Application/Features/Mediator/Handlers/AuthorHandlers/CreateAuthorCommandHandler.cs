using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler(IRepository<Author> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateAuthorCommand, GetAuthorByIdQueryResult>
    {
        public async Task<GetAuthorByIdQueryResult> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Author>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetAuthorByIdQueryResult>(entity);
        }
    }
}