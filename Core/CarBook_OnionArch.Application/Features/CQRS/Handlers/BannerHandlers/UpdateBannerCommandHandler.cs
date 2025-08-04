using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.AboutCommands;
using CarBook_OnionArch.Application.Features.CQRS.Commands.BannerCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler(IRepository<Banner> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(UpdateBannerCommand command)
        {
            var entity = mapper.Map<Banner>(command);
            repository.Update(entity);
            return await unitOfWork.CommitAsync();
        }
    }
}
