using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarPricingResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class CreateCarPricingQueryHandler(IRepository<CarPricing> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateCarPricingCommand, GetCarPricingByIdQueryResult>
    {
        public async Task<GetCarPricingByIdQueryResult> Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CarPricing>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetCarPricingByIdQueryResult>(entity);
        }
    }
}