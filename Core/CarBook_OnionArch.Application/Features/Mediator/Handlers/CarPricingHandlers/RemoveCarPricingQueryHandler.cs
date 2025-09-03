using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    internal class RemoveCarPricingQueryHandler(IRepository<CarPricing> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateCarPricingCommand, bool>
    {
        public async Task<bool> Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CarPricing>(request);
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