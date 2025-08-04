using CarBook_OnionArch.Application.Features.CQRS.Commands.ContactCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler(IRepository<Contact> repository,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(RemoveContactCommand command)
        {
            await repository.RemoveAsync(command.Id);
            return await unitOfWork.CommitAsync();
        }
    }
}
