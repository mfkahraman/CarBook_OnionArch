using CarBook_OnionArch.Application.Features.Mediator.Commands.LocationCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler(IRepository<Location> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveLocationCommand, bool>
    {
        public async Task<bool> Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
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