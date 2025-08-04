using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.BrandCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler(IRepository<Brand> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(UpdateBrandCommand command)
        {
            var entity = mapper.Map<Brand>(command);
            repository.Update(entity);
            return await unitOfWork.CommitAsync();
        }
    }
}
