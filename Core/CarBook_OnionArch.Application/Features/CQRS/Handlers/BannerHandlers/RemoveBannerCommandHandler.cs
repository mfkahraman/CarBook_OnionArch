using CarBook_OnionArch.Application.Features.CQRS.Commands.BannerCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler(IRepository<Banner> repository,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(RemoveBannerCommand command)
        {
            await repository.RemoveAsync(command.Id);
            return await unitOfWork.CommitAsync();
        }
    }
}
