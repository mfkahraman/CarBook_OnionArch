using CarBook_OnionArch.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class CreateCarPricingCommand : IRequest<GetCarPricingByIdQueryResult>
    {
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
