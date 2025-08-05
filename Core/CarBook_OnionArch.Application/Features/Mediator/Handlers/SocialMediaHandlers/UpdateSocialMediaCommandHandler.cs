using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateSocialMediaCommand, bool>
    {
        public async Task<bool> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<SocialMedia>(request);
            repository.Update(entity);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Db güncelleme işlemi sırasında bir sorun oluştu.");
            }
            return true;
        }
    }
}