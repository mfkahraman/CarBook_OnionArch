using CarBook_OnionArch.Application.Features.CQRS.Commands.CarCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler(IRepository<Car> repository,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(RemoveCarCommand command)
        {
            await repository.RemoveAsync(command.Id);
            return await unitOfWork.CommitAsync();
        }
    }
}
