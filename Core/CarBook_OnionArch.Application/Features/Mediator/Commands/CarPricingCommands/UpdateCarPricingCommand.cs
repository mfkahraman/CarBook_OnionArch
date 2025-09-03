using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class UpdateCarPricingCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
