using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class UpdateCarDescriptionCommandHandler(IRepository<CarDescription> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateCarDescriptionCommand, bool>
    {
        public async Task<bool> Handle(UpdateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CarDescription>(request);
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