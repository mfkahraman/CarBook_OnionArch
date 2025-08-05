using CarBook_OnionArch.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveFooterAddressCommand, bool>
    {
        public async Task<bool> Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
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
