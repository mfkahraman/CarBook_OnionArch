using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler(IRepository<Feature> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateFeatureCommand, GetFeatureByIdQueryResult>
    {
        public async Task<GetFeatureByIdQueryResult> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = mapper.Map<Feature>(request);
            repository.Create(feature);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetFeatureByIdQueryResult>(feature);
        }
    }
}
