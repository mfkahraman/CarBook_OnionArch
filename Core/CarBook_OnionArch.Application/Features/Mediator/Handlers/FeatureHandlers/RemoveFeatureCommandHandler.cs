using CarBook_OnionArch.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler(IRepository<Feature> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveFeatureCommand, bool>
    {
        public async Task<bool> Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
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
