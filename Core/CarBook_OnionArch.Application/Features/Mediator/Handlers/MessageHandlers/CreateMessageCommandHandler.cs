using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.MessageCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.MessageHandlers
{
    internal class CreateMessageCommandHandler(IRepository<Message> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateMessageCommand, bool>
    {
        public async Task<bool> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Message>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return true;
        }
    }
}