using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.AboutCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.AboutResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler(IRepository<About> repository,
                                           IMapper mapper,
                                           IUnitOfWork unitOfWork)
    {
        public async Task<GetAboutByIdQueryResult> Handle(CreateAboutCommand command)
        {
            var about = mapper.Map<About>(command);
            repository.Create(about);
            await unitOfWork.CommitAsync();
            return mapper.Map<GetAboutByIdQueryResult>(about);
        }
    }
}
