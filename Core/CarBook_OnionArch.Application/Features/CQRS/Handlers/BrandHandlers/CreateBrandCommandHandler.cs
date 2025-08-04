using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.BrandCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.BrandResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler(IRepository<Brand> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<GetBrandByIdQueryResult> Handle(CreateBrandCommand command)
        {
            var entity = mapper.Map<Brand>(command);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Dbye kayıt işlemi sırasında bir hata oluştu");
            }

            return mapper.Map<GetBrandByIdQueryResult>(entity);
        }
    }
}
