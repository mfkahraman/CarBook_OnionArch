using CarBook_OnionArch.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class RemoveCarFeatureCommandHandler(IRepository<CarFeature> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveCarFeatureCommand, bool>
    {
        public async Task<bool> Handle(RemoveCarFeatureCommand request, CancellationToken cancellationToken)
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