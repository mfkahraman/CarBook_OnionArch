using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.BrandCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler(IRepository<Brand> repository,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(RemoveBrandCommand command)
        {
            await repository.RemoveAsync(command.Id);
            return await unitOfWork.CommitAsync();
        }
    }
}
