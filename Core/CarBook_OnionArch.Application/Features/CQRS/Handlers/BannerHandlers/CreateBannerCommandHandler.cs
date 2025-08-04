using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.AboutCommands;
using CarBook_OnionArch.Application.Features.CQRS.Commands.BannerCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.AboutResults;
using CarBook_OnionArch.Application.Features.CQRS.Results.BannerResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler(IRepository<Banner> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<GetBannerByIdQueryResult> Handle(CreateBannerCommand command)
        {
            var entity = mapper.Map<Banner>(command);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Dbye kayıt işlemi sırasında bir hata oluştu");
            }

            return mapper.Map<GetBannerByIdQueryResult>(entity);
        }
    }
}
