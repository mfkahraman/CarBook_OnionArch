using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.AboutCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler(IRepository<About> repository,
                                           IMapper mapper)
    {
        public async Task Handle(UpdateAboutCommand command)
        {
            var about = mapper.Map<About>(command);
            await repository.UpdateAsync(about);
        }
    }
}
