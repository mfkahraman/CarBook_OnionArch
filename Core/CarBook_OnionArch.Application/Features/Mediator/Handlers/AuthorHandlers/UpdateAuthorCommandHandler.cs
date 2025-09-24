using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler(IRepository<Author> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateAuthorCommand, bool>
    {
        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Author>(request);
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
