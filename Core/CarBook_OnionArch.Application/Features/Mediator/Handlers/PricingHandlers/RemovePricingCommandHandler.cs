using CarBook_OnionArch.Application.Features.Mediator.Commands.PricingCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler(IRepository<Pricing> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemovePricingCommand, bool>
    {
        public async Task<bool> Handle(RemovePricingCommand request, CancellationToken cancellationToken)
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