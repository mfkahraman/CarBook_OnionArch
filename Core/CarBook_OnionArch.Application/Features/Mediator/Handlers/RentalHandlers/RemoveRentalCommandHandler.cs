using CarBook_OnionArch.Application.Features.Mediator.Commands.RentalCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.RentalHandlers
{
    public class RemoveRentalCommandHandler(IRepository<Rental> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveRentalCommand, bool>
    {
        public async Task<bool> Handle(RemoveRentalCommand request, CancellationToken cancellationToken)
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