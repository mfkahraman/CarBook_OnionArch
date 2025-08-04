using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.CategoryResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler(IRepository<Category> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<GetCategoryByIdQueryResult> Handle(CreateCategoryCommand command)
    {
        var entity = mapper.Map<Category>(command);
        repository.Create(entity);
        var result = await unitOfWork.CommitAsync();

        if (!result)
        {
            throw new Exception("Dbye kayıt işlemi sırasında bir hata oluştu");
        }

        return mapper.Map<GetCategoryByIdQueryResult>(entity);
    }
}
}
