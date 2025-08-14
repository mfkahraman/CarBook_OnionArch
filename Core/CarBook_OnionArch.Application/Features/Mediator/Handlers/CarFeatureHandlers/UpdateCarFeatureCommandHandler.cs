using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureCommandHandler(IRepository<CarFeature> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateCarFeatureCommand, bool>
    {
        public async Task<bool> Handle(UpdateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CarFeature>(request);
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