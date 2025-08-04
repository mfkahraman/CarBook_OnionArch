using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(UpdateCategoryCommand command)
        {
            var entity = mapper.Map<Category>(command);
            repository.Update(entity);
            return await unitOfWork.CommitAsync();
        }
    }
}
