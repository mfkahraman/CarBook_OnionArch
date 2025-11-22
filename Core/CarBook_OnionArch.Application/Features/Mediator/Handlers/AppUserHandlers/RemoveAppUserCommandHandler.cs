using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class RemoveAppUserCommandHandler(IRepository<AppUser> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveAppUserCommand, bool>
    {
        public async Task<bool> Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
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