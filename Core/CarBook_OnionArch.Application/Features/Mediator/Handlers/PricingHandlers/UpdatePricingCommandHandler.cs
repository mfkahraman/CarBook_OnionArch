using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.PricingCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler(IRepository<Pricing> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdatePricingCommand, bool>
    {
        public async Task<bool> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Pricing>(request);
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
