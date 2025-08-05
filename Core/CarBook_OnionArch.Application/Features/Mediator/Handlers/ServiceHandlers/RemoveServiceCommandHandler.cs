using CarBook_OnionArch.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler(IRepository<Service> repository,
                                             IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveServiceCommand, bool>
    {
        public async Task<bool> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
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