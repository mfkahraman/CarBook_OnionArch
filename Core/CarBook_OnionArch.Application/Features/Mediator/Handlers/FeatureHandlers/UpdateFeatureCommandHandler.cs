using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler(IRepository<Feature> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateFeatureCommand, bool>
    {
        public async Task<bool> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = mapper.Map<Feature>(request);
            repository.Update(feature);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Db güncelleme işlemi sırasında bir sorun oluştu.");
            }
            return true;
        }
    }
}
