using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler(IRepository<Service> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateServiceCommand, bool>
    {
        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Service>(request);
            repository.Update(entity);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Db güncelleme işlemi sırasında bir sorun oluştu.");
            }
            return true;
        }
    }
}