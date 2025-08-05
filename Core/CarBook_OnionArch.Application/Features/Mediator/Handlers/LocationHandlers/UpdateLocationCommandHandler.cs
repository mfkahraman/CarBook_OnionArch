using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.LocationCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler(IRepository<Location> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateLocationCommand, bool>
    {
        public async Task<bool> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Location>(request);
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
