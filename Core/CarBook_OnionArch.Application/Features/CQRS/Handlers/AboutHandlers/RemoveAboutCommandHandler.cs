using CarBook_OnionArch.Application.Features.CQRS.Commands.AboutCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler(IRepository<About> repository)
    {
        public async Task Handle(RemoveAboutCommand command)
        {
            await repository.RemoveAsync(command.id);
        }
    }
}
