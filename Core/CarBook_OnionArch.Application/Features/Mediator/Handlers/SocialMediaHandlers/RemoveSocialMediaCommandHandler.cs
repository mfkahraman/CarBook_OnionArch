using CarBook_OnionArch.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveSocialMediaCommand, bool>
    {
        public async Task<bool> Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await repository.RemoveAsync(request.Id);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Dbde silme işlemi sırasında bir sorun oluştu");
            }
            return true;
        }
    }
}