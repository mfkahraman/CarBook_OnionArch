using CarBook_OnionArch.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class RemoveCarDescriptionCommandHandler(IRepository<CarDescription> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveCarDescriptionCommand, bool>
    {
        public async Task<bool> Handle(RemoveCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            await repository.RemoveAsync(request.id);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Dbde silme işlemi sırasında bir sorun oluştu");
            }
            return true;
        }
    }
}