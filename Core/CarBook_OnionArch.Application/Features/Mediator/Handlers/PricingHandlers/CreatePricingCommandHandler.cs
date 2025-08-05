using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.PricingCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.PricingResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler(IRepository<Pricing> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreatePricingCommand, GetPricingByIdQueryResult>
    {
        public async Task<GetPricingByIdQueryResult> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Pricing>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetPricingByIdQueryResult>(entity);
        }
    }
}