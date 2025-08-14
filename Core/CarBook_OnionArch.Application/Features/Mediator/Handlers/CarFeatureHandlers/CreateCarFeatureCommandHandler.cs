using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureCommandHandler(IRepository<CarFeature> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateCarFeatureCommand, GetCarFeatureQueryResult>
    {
        public async Task<GetCarFeatureQueryResult> Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CarFeature>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetCarFeatureQueryResult>(entity);
        }
    }
}